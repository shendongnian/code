     int linenum = 0;
                    foreach (var line in File.ReadAllLines("Your Address"))
                    {
                        if (line.Contains("medication"))
                        {
                            Console.WriteLine(string.Format("line Number:{} Text:{}"linenum,line)
    //Add to your list or ...
                        }
                        linenum++;
                    }
