    public static class WorkbookExtensions
    {
        public static long GetHashery(this msExcel.Workbook workbook)
        {
            if (workbook == null)
            {
                throw new ArgumentNullException("workbook");
            }
            IntPtr pUnknown = IntPtr.Zero;
            try
            {
                pUnknown = Marshal.GetIUnknownForObject(workbook);
                return pUnknown.ToInt64();
            }
            finally
            {
                // GetIUnknownForObject causes AddRef.
                if (pUnknown != IntPtr.Zero)
                {
                    Marshal.Release(pUnknown);
                }
            }
        }
    }
