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
