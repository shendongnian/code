    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    
    namespace ConsoleReadWriteTest
    {
        class Program
        {
            private static ConsoleInfo consoleInfo = new ConsoleInfo();
            static void Main(string[] args)
            {
                Thread consoleWriter = new Thread(new ThreadStart(ConsoleWriter));
                consoleWriter.Start();
    
                consoleInfo.outputBuffer.Add("Running.");
                consoleInfo.outputBuffer.Add(".. status of foo = good");
                consoleInfo.outputBuffer.Add(".. status of bar = bad");
    
                while (true)
                {
                    var key = Console.ReadKey(true);
                    lock (consoleInfo)
                    {
                        if (key.Key == ConsoleKey.Enter)
                        {
                            consoleInfo.commandReaty = true;
                        }
                        else
                        {
                            consoleInfo.sbRead.Append(key.KeyChar.ToString());
                        }
                    }
                }
    
            }
    
            static void ConsoleWriter()
            {
                while (true)
                {
                    lock(consoleInfo)
                    {
                        Console.Clear();
    
                        if (consoleInfo.outputBuffer[0].Length > 20)
                        {
                            consoleInfo.outputBuffer[0] = "Running.";
                        }
                        else
                        {
                            consoleInfo.outputBuffer[0] += ".";
                        }
    
                        foreach (var item in consoleInfo.outputBuffer)
                        {
                            Console.WriteLine(item);
                        }
    
                        Console.WriteLine("--------------------------------------------------------------");
    
                        if (consoleInfo.commandReaty)
                        {
                            consoleInfo.commandReaty = false;
                            consoleInfo.lastCommand = consoleInfo.sbRead.ToString();
                            consoleInfo.sbRead.Clear();
                            consoleInfo.lastResult.Clear();
                            switch (consoleInfo.lastCommand)
                            {
                                case "command1":
                                    consoleInfo.outputBuffer[2] = ".. status of bar = good";
                                    consoleInfo.lastResult.Append("command #1 performed");
    
                                    break;
                                case "command2":
                                    consoleInfo.outputBuffer[2] = ".. status of bar = bad";
                                    consoleInfo.lastResult.Append("command #2 performed");
                                    break;
                                case "?":
                                    consoleInfo.lastResult.AppendLine("Available commands are:");
                                    consoleInfo.lastResult.AppendLine("command1     sets bar to good");
                                    consoleInfo.lastResult.AppendLine("command1     sets bar to bad");
                                    break;
                                default:
                                    consoleInfo.lastResult.Append("invalid command, type ? to see command list");
                                    break;
                            }
                        }
    
                        Console.WriteLine(consoleInfo.lastCommand);
                        Console.WriteLine(consoleInfo.lastResult);
                        Console.WriteLine();
                        Console.Write(">");
                        Console.WriteLine(consoleInfo.sbRead.ToString());
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                    }
    
                    Thread.Sleep(250);
                }
            }
            private class ConsoleInfo
            {
                public bool commandReaty { get; set; }
                public StringBuilder sbRead { get; set; }
                public List<string> outputBuffer { get; set; }
                public string lastCommand { get; set; }
                public StringBuilder lastResult { get; set; }
    
                public ConsoleInfo()
                {
                    sbRead = new StringBuilder();
                    outputBuffer = new List<string>();
                    commandReaty = false;
                    lastResult = new StringBuilder();
                }
            }
        }
    }
