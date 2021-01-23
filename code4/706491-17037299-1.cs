     class TestClass
     {
         static void Main(string[] args)
         {
               //Now you have all arguments in the string array
               if(args.Length != 0)
               {
                     string pathToTextfile = args[0];
               }
               StreamReader textFile = new StreamReader(pathToTextfile);
               string fileContents = textFile.ReadToEnd();
               textFile.Close();
         }
     }
