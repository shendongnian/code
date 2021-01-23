        public static class WorkbookExtensions
        {
            public static int GetHashery(this msExcel.Workbook workbook)
            {
                IntPtr punk = IntPtr.Zero;
                if (workbook == null)
                    return punk.ToInt32();    
                try
                {
                    punk = Marshal.GetIUnknownForObject(workbook);
                    return punk.ToInt32();
                }
                finally
                {
                    //Release to decrease ref count
                    Marshal.Release(punk);
                }
            }
        }
