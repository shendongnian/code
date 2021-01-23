    int i = 0;
            try
            {
                int j = 1 / i; // Generate a divide by 0 exception.
            }
            catch(Exception e)
            {
                Console.Out.WriteLine("Exception caught");
            }
            finally
            {
                Console.Out.WriteLine("Finished");
                Console.In.ReadLine();
            }
