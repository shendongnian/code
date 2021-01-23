     int linenum = 0;
                    foreach (var line in File.ReadAllLines("Your Address"))
                    {
                        if (line.Contains("medication"))
                        {
                            Console.WriteLine(linenum)
    //Add to your list or ...
                        }
                        linenum++;
                    }
