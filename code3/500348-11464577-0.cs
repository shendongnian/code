        static public void Insert(Cat[] cats)
        {
         try {
            //Your code here
         } catch (Exception ex ) {
            Exception ex2 = ex;
            while( ex2.InnerException != null ) {
                 ex2 = ex2.InnerException;
            }
            Console.WriteLine( ex.InnerException );
            throw;
         }
        }
