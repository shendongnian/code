        public class DataObjectEx :
            DataObject, System.Runtime.InteropServices.ComTypes.IDataObject
        {
            private static readonly TYMED[] ALLOWED_TYMEDS =
                new TYMED[] { 
                TYMED.TYMED_ENHMF,
                TYMED.TYMED_GDI,
                TYMED.TYMED_HGLOBAL,
                TYMED.TYMED_ISTREAM, 
                TYMED.TYMED_MFPICT};
            public void FormDataObject(ListViewItem item)
            {
                var formatmumber=(Int16)DataFormats.GetFormat(NativeMethods.CFSTR_FILECONTENTS).Id;
                //формируем структуру для shell
                formatetc = new FORMATETC();
                formatetc.cfFormat = formatmumber;
                formatetc.ptd = IntPtr.Zero;
                formatetc.dwAspect = DVASPECT.DVASPECT_CONTENT;
                formatetc.lindex = -1;
                formatetc.tymed = TYMED.TYMED_ISTREAM;
                //формируем структуру для передачи данных в shell
                medium = new STGMEDIUM();
                medium.tymed = TYMED.TYMED_ISTREAM;
                MemoryStream = GetFileContents(item);
                //IStream ob1;
                medium.unionmember = Marshal.GetComInterfaceForObject(iStream, typeof(MemoryStream));
                //medium.unionmember = iStream;
                
                ((System.Runtime.InteropServices.ComTypes.IDataObject)ob).SetData(ref formatetc, ref medium, true);
                
            }
