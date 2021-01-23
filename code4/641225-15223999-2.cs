        static void Main()
        {
            try
            {
                //Your code
            }
            catch (Exception ex)
            {
                //Write ex.Message to a file
                using (StreamWriter outfile = new StreamWriter(@".\error.txt"))
                {
                     outfile.Write(ex.Message.ToString());
                }
            }
        }
