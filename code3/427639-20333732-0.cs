        public static void read()
        {
             StreamReader readme = null;
    
             try
             {
                  readme = File.OpenText(@"C:\path\to\your\.txt\file.txt");
                  Console.WriteLine(readme.ReadToEnd());
             }
             // will return an invalid file name error
             catch (FileNotFoundException errorMsg)
             {
                  Console.WriteLine("Error, " + errorMsg.Message);
             }
             // will return an invalid path error
             catch (Exception errorMsg)
             {
                 Console.WriteLine("Error, " + errorMsg.Message);
             }
             finally
             {
                  if (readme != null)
                  {
                      readme.Close();
                  }
             }
        }
