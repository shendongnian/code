                        string oldname=sName;
                        string youngname=sName;
                         
                  
                        foreach (var mo in students)
                        {
                            int result = DateTime.Compare(mo.dob, mv);
                            if (result == -1)
                            {
                                mv = mo.dob;
                                oldname = mo.name;
                            }
                            if (result == 1)
                            {
                                mv = mo.dob;
                                youngname = mo.name;
                            }
                        }
                            
                        Console.WriteLine("the youngest student is: {0}", youngname);
                        Console.WriteLine();
                        Console.WriteLine("the oldest student is: {0}", oldname);
                        Console.WriteLine();
