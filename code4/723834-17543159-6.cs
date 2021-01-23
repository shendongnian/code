        public void Dispose()
        {
            if (autoSave)
            {
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {      
                    if(!ExceptionsIgnoredOnSave.Any(pass => pass(ex)))
                        throw;
                    Console.WriteLine("ignoring exception..."); // temp
                }
            }
            context.Dispose();
        }
