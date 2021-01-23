       TextReader tr = new StreamReader(@"Path of appcode");
 
      //Reading all the text of the file.
       Console.WriteLine(trs.ReadToEnd());
 
      //Or Can Reading a line of the text file.
      Console.WriteLine(trs.ReadLine());
 
      //Close the file.
      trs.Close();
 
      Console.WriteLine("Press any key to exit...");
      Console.ReadKey();
