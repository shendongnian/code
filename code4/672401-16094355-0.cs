    for (int k = 0; k < 4; k++)
                {
                    string line = Console.ReadLine();
                    if (!int.TryParse(line, out packageInfo[k]))
                    {
                        Console.WriteLine("Couldn't parse {0} - please enter integers", line);
                        k--;
                    }
                }
    
    packageInfo[4] = height * width * length;
    packageInfo[5] = (2 * length + 2 * width);
