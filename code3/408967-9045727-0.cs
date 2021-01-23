    if (DateTime.Now.Hour >= 9 && DateTime.Now.Hour <= 18) { Console.WriteLine("Bonjour " + Environment.UserName); }
                        else
                        {
                            Console.WriteLine("Bonsoir " + Environment.UserName);
                        }
