            try
            {
                List<Exception> exceptions = null;
                foreach (object myObject in myObjects)
                {                    
                    try
                    {
                        string str = (string)myObject;
                        if (str != null)
                        {
                            sw.WriteLine(str);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (exceptions == null)
                            exceptions = new List<Exception>();
                        exceptions.Add(ex);
                    }
                }
                if (exceptions != null) 
                    throw new AggregateException(exceptions);                
            }
            catch(AggregateException ae)
            {
                //Do whatever you want with the exception or throw it
                throw ae;
            }   
