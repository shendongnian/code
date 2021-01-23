                    int count = 0;
                    while (count < 10)
                    {
                        Console.Write(" Enter your ID: ");
                        int ID = int.Parse(Console.ReadLine());
        
                        Console.Write(" Enter your Name: ");
                        string Name = Console.ReadLine();
        
                        string output = string.Format("Thank you! you are logged in as {0} {1}", Name, ID);
                        Console.WriteLine(output);
                        File.AppendAllText("fileone.txt", output + Environment.NewLine);
        
                        count++;
                    }
