         try 
        {
             using (StreamReader sr = new StreamReader("Encoding.txt")) 
            {
                string line;
                for (int i =0; i < lines; i++) 
                {
                    line = sr.Readline();
                    if (!line.startsWith('#')) //ignore comments
                    {
                         string[] tokens = line.Split('='); //split for key and value
                         foreach(string token in tokens)
                               token.Trim(' '); // remove whitespaces
                        tuples[i].Item1 = tokens[0];
                        tuples[i].Item2 = tokens[1];
                    }   
                }
            }
        }
        catch (Exception e) 
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
