    public class Class1
    {
        public class test
        {
            public void testMethod()
            {
                DataTable dt = null;
                DataView dv = null;
    
    
             try
            {
                // dt must be assigned a value only within the try block
                dt = new DataTable(dt);
                dv = new DataView(dt);
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
