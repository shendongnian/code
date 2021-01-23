    class Program
        {
            static void Main(string[] args)
            {
                byte[] data = {};
                //using (Bitmap bitmap = new Bitmap(new MemoryStream(data)))
                //{ }
    
                MemoryStream mem = null;
                Bitmap bitmap = null;
                try
                {
                    mem = new MemoryStream(data);
                    bitmap = new Bitmap(mem);
    
                }
                catch (Exception)
                {
    
                    throw;
                }
                finally
                {
                    if (null!= bitmap ) bitmap.Dispose();                
                    // commenting this out will provoke a CA2000.
                    // uncommenting this will provoke CA2202.
                    // so pick your poison.
                    // if (null != mem) mem.Dispose();
                }
            } 
        }
