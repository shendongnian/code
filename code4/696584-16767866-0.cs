            try
            {
                return ReadAllText("path", "text", "error");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            return false;
