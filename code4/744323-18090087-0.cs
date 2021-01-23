        string[] Lines;
        string[] myArray;
        Lines = File.ReadAllLines(your file path);
        
         
        
            for (int i = 0; i < Lines.Length; i++)
             {
                        myArray = Lines[i].Split(',');
            
             }
             for (int j = 0; j < myArray .Length; j++)
             {
                            string x =myArray [j].ToString();
                            x = Regex.Replace(x, "[^0-9.]", "");
                            
                            Console.WriteLine(x);
             }
