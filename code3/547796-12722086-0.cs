                var splittedData = str.Split(' ');
                if (splittedData != null && splittedData.Length > 0)
                {
                    int _number;
                    if (!int.TryParse(splittedData[0], out _number))
                    {
                        Console.WriteLine("Not a number");
                    }
                    else
                    {
                        Console.WriteLine("Got this number - {0}", _number);
                    }
                }
                Console.ReadLine();
