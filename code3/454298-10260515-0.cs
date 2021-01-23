            try
            {
                Console.WriteLine("Try");
                Environment.FailFast("Test Fail");
            }
            catch (Exception)
            {
                Console.WriteLine("catch");
            }
            finally
            {
                Console.WriteLine("finally");
            }
