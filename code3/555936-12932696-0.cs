        if (args.Length != 1)
                {
                    // Display title, reset cursor to normal, add space
                    Console.WriteLine("Alt ver 1.0 (Alpha)");
                    Console.WriteLine();
                    Console.ReadLine();
                    try
                    {
                        Scanner scanner = null;
                        using (TextReader input = File.OpenText(args[0]))
                        {
                            scanner = new Scanner(input);
                        }
                        Parser parser = new Parser(scanner.Tokens);
                        CodeGen codeGen = new CodeGen(parser.Result, Path.GetFileNameWithoutExtension(args[0]) + ".exe");
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e.Message);
                        Console.ReadLine();
                    }
    finally
    {
    Console.Readkey();
    }
                } //if
    else
    {
    Console.WriteLine("no args");
    Console.ReadKey();
    }
