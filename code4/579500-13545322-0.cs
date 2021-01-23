         try
            {
                int a = 10;
                int b = 20;
                int z = a + b;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Executed");
            }
