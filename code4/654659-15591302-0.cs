    using System;
    using System.Diagnostics.SymbolStore;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Linq;
    public static class AssemblyDirectoryInfo
    {
        private const string
            ImporterId = "7DAC8207-D3AE-4c75-9B67-92801A497D44",
            DispenserId = "809c652e-7396-11d2-9771-00a0c9b4d50c",
            DispenserClassId = "e5cb7a31-7512-11d2-89ce-0080c792e5d8";
        [Guid(ImporterId), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComVisible(true)]
        public interface IMetaDataImport{}
        [Guid(DispenserId), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComVisible(true)]
        interface IMetaDataDispenser
        {
            void DefineScope();
            void OpenScope([In, MarshalAs(UnmanagedType.LPWStr)] String szScope, [In] Int32 dwOpenFlags,
                           [In] ref Guid riid, [Out, MarshalAs(UnmanagedType.IUnknown)] out Object punk);
        }
        [DllImport("ole32.dll")]
        private static extern int CoCreateInstance([In] ref Guid guid,
            [In, MarshalAs(UnmanagedType.IUnknown)] Object pUnkOuter,
            [In] uint dwClsContext,
            [In] ref Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out Object ppv);
        public static DirectoryInfo GetAssemblyCodeBase(Assembly assembly)
        {
            var file = new FileInfo(assembly.Location);
            Guid dispenserClassId = new Guid(DispenserClassId),
                 importerIid = new Guid(ImporterId),
                 dispenserIid = new Guid(DispenserId);
            object dispenser, importer;
            CoCreateInstance(ref dispenserClassId, null, 1, ref dispenserIid, out dispenser);
            ((IMetaDataDispenser)dispenser).OpenScope(file.Name, 0, ref importerIid, out importer);
            var ptr = Marshal.GetComInterfaceForObject(importer, typeof(IMetaDataImport));
            var reader = new SymBinder().GetReader(ptr, file.Name, file.DirectoryName);
            return reader.GetDocuments()
                         .Select(d => d.URL)
                         .Where(v => !string.IsNullOrEmpty(v))
                         .OrderBy(v => v.Length)
                         .Select(v => new FileInfo(v).Directory)
                         .First();
        }
    }
