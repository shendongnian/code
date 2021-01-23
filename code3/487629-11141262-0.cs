    using System;
    using System.Linq;
    namespace SOSimpleCLI
    {
        class Program
        {
            static void Main(string[] args)
            {
                string cmdLine = null;
                while (cmdLine != "end")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("SOSimpleCLI: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    cmdLine = Console.ReadLine();
                    string[] cmd = cmdLine.Split(' ');
                    switch (cmd.FirstOrDefault())
                    {
                        case "cmd1":
                            Console.WriteLine(Cmd1());
                            break;
                        case "cmd2":
                            if (cmd.Length != 2)
                            {
                                Console.WriteLine("Wrong number of args for cmd2");
                            }
                            else
                            {
                                Console.WriteLine(Cmd2(cmd[1]));
                            }
                            break;
                    }
                }
            }
            static string Cmd1()
            {
                return "Came from command 1";
            }
            static string Cmd2(string arg)
            {
                return string.Format("Came from command 2: {0}", arg);
            }
        }
    }
