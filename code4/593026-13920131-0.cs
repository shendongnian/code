            try
            {
                work(client);
                client.Close();
            }
                     
            catch (Exception e)
            {
                client.Abort();
                throw;
            }
   
