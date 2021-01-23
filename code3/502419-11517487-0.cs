    StreamReader reader = new (File.OpenRead(@"YourFile.txt"));
    List<string> LstIntegers = new List<string>();
    
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    //values is actually a string array.
                    var values = line.Split(',');
                    //add the entire array fetched into string List
    		LstIntegers.AddRange(values); 	
                }
              // important to close the reader. You can also use using statement for reader. It 
              // will close the reader automatically when reading finishes.
                reader.Close();
    
       // You can then further manipulate it like below, you can also use int.Parse or int.TryParse:
       foreach (var v in LstIntegers)
       {
          // use int.TryParse if there is a chance that a non-int is read.
          int someNum = Convert.ToInt32(v);
    
       }
