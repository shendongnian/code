            try
            {
                Console.WriteLine("Try");
                throw new Exception();
            }
            finally
            {
                Console.WriteLine("finally");
            }
