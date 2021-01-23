       for (int i = 1; i < n; i++)
                {
                    try
                    {
                        from = System.IO.Path.Combine(@"E:\vid\","(" + i.ToString() + ").PNG");
                        to = System.IO.Path.Combine(@"E:\ConvertedFiles\",i.ToString().PadLeft(6,'0') + ".png");
    
                        File.Move(from, to); // Try to move
                        Console.WriteLine("Moved"); // Success
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine(ex); // Write error
                    }
                }
