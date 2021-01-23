    class ExceptionHandling
    {
        public static void Main(string[] args)
        {
            StreamReader streamReader = null;
            try
            {
            streamReader = new StreamReader("C:\\bin\\C#\\readfil1e\\data.txt");//or @"c:\bin\c#\readfile\data.txt");
            }
            catch(Exception ex)
            {
            }
            finally
            {
            if (streamReader == null)
              {
                Console.WriteLine("FILE NOT READABLE");
                Console.ReadLine();
              }
            else
              {
              Console.WriteLine(streamReader.ReadToEnd());
              Console.ReadLine();
              streamReader.Close();
              }
            }//finally
        }
    }
