    public static class ComBlackBox
    {
        public static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (ArgumentException ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        } 
    }
