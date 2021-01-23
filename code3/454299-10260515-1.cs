            try
            {
                Console.WriteLine("Try");
                Rec();
            }
            catch (Exception)
            {
                Console.WriteLine("catch");
            }
            finally
            {
                Console.WriteLine("finally");
            }
