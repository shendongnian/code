        static void Main(string[] args)
        {
            try
            {
                throw new FormatException("Format");
            }
            catch (Exception ex)
            {
                if (ex is FormatException || ex is OverflowException)
                {
                    Console.WriteLine("Caught Exception");
                    return;
                }
                throw;
            }
            // add this
            finally
            {
                Console.Read();      
            }
        }
