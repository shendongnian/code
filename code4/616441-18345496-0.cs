    public static class TryCatch
    {
        public static T Expression<T>(Func<T> lamda, Action<Exception> onException)
        {
            try
            {
                return lamda();
            }
            catch(Exception e)
            {
                onException(e);
                return default(T);
            }            
        }
 
    }
    
    //and example
 
    Exception throwexception = null;
            var results = TryCatch.Expression(
                //TRY
                () => 
                    {
                        //simulate exception happening sometimes.
                        if (new Random().Next(3) == 2)
                        {
                            throw new Exception("test this");
                        }
                        //return an anonymous object
                        return new { a = 1, b = 2 };
                    } ,
                //CATCH
                (e) => { throwexception = e;                         
                         //retrow if you wish
                         //throw e;
                       }
                );
