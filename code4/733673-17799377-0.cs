    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    
    static class Program
    {
        // Pass a PDB file name as a command-line parameter
        static void Main(string[] args)
        {
            var pdbFile = args.FirstOrDefault();
            if (!File.Exists(pdbFile))
                return;
    
            try
            {
                var dataSource = (IDiaDataSource)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("83AB22C8-993A-4D14-A0E0-37BC0AAEA793")));
                dataSource.LoadDataFromPdb(pdbFile);
    
                IDiaSession session;
                dataSource.OpenSession(out session);
    
                var globalScope = session.GlobalScope;
                Console.WriteLine(globalScope.Guid.ToString("N").ToUpperInvariant() + globalScope.Age.ToString("X"));
            }
            catch (COMException) { } // May happen for corrupted PDB files
        }
    }
    
    
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("79F1BB5F-B66E-48E5-B6A9-1545C323CA3D")]
    interface IDiaDataSource
    {
        void _VtblGap_1();
        void LoadDataFromPdb(string pdbFile);
        void _VtblGap_3();
        void OpenSession(out IDiaSession session);
    }
    
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6FC5D63F-011E-40C2-8DD2-E6486E9D6B68")]
    interface IDiaSession
    {
        void _VtblGap_2();
        IDiaSymbol GlobalScope { get; }
    }
    
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CB787B2F-BD6C-4635-BA52-933126BD2DCD")]
    interface IDiaSymbol
    {
        void _VtblGap_43();
        Guid Guid { get; }
        void _VtblGap_28();
        uint Age { get; }
    }
