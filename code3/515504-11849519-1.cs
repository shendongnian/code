                using (StreamReader sr = new StreamReader(yourPath)) 
                {
                    //This is an arbitrary size for this example.
                    char[] c = null;
    
                    while (sr.Peek() >= 0) 
                    {
                        c = new char[5];//Read block of 5 characters
                        sr.Read(c, 0, c.Length);
                        Console.WriteLine(c); //print block
                    }
                }
