    public class Class1
    {
        public class test
        {
            public void testMethod()
            {
                DataTable dt = null;
             try
            {
                dt = new DataTable();
             }
            catch
            { }
            finally
            {
                if (dt != null) dt.Dispose();
                if (dv != null) dv.Dispose();
             }
        }
        }
    }
