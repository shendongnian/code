         //A list of arrays of integers
         //A single array will have numbers from a single line
         List<int[]> allNumbers = new List<int[]>();
         TextReader tr = new StreamReader("Data.txt");
         string word = tr.ReadLine();
         // write a line of text to the file
         while ( word !=  null ) {
    
             //now split this line into words
             string[] vals = word.Split(new Char[] { ',' });
             int[] intVals = new int[vals.Length];
               
             for ( int i = 0; i < vals.Length; i++) {
                 Int32.TryParse(vals[i], out intVals[i]);
             }
             
             //Add this array of integers into allNumbers
             allNumbers.Add(intVals);
             //Now read the next line
             word = tr.ReadLine();
         }
    }
