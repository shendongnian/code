    public static class DataTableExtensions
    {
        public static void SpecialMethod(this DataTable dt)
        {
            //do something
        }
    }
--
    DataTable dt = .........
    dt.SpecialMethod();
