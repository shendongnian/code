    static void Main(string[] args)
    {
        bool only2 = false;
        StringBuilder outputFile = new StringBuilder();
        if (args.Length == 2)
        {             
            try
            {
                System.IO.File.Delete(args[1]);
            }
            catch
            {
                Console.WriteLine("No file to delete");
            }
    
            System.IO.File.Move(args[0], args[1]);
            only2 = true;               
        }
        int endArg = args.Length;
        Console.WriteLine(endArg.ToString());
        int c = 0;                  
        if(!only2)
        {
            foreach (string a in args)
            {
                if (c == (endArg - 1))
                {
                    System.IO.TextWriter w = new System.IO.StreamWriter(a);
                    w.Write(outputFile);
                    w.Flush();
                    w.Close();
                    break;
                }
                else
                {
                    if (c == 0)
                    {
                        using (StreamReader sr = new StreamReader(a))
                        {
                            while (sr.Peek() >= 0)
                            {
                                string grabLine = sr.ReadLine();
                                if (grabLine.Contains("<div class=\"test-name\">Coded UI Test Log</div>"))
                                {
                                    outputFile.AppendLine("<div class=\"test-name\">Test " + (c + 1).ToString() + "</div>");
                                }
                                else
                                {
                                    if (!grabLine.Contains("</body>") | !grabLine.Contains("</html>"))
                                    {
                                        outputFile.AppendLine(grabLine);
                                    }
                                }
                            }
                        }
                    }
                    if (c != 0 && c != (endArg - 2))
                    {
                        bool notYet = false;
                        using (StreamReader sr = new StreamReader(a))
                        {
                            while (sr.Peek() >= 0)
                            {
                                string grabLine = sr.ReadLine();
    
    
                                if (grabLine.Contains("<body>"))
                                {
                                    notYet = true;
                                }
                                if (grabLine.Contains("<div class=\"test-name\">Coded UI Test Log</div>"))
                                {
                                    outputFile.AppendLine("<div class=\"test-name\">Test " + (c + 1).ToString() + "</div>");
                                }
                                else
                                {
                                    if (notYet)
                                    {
                                        if (!grabLine.Contains("</body>") | !grabLine.Contains("</html>"))
                                        {
                                            outputFile.AppendLine(grabLine);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (c == (endArg - 2))
                    {
                        bool notYet = false;
                        using (StreamReader sr = new StreamReader(a))
                        {
                            while (sr.Peek() >= 0)
                            {
                                string grabLine = sr.ReadLine();
                                if (grabLine.Contains("<body>"))
                                {
                                    notYet = true;
                                }
                                if (notYet)
                                {
                                    if (grabLine.Contains("<div class=\"test-name\">Coded UI Test Log</div>"))
                                    {
                                        outputFile.AppendLine("<div class=\"test-name\">Test " + (c + 1).ToString() + "</div>");
                                    }
                                    else
                                    {
                                        outputFile.AppendLine(grabLine);
                                    }
                                }
                            }
                        }
                    }
                }
                c++;
            }
        }
    }
