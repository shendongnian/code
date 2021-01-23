                   try
                    {
                        TextWriter tw = new StreamWriter(textfile_name); //clean the text file
                        tw.WriteLine(" ");
                        tw.Close();
                        TextWriter tw2 = new StreamWriter(textfile_name, true);  //append <Lines> as the first new line on the text file
                        tw2.WriteLine("Lines");
                        tw2.Close();
                    }
                    catch {
                        Console.WriteLine("cant re-write txt");
                    }
