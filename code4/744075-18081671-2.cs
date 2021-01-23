    Process[] processes = Process.GetProcessesByName("notepad");
            for (int i = 0; i < processes.Length; i++)
            {
                Console.WriteLine(processes[i].MainWindowTitle);
                if (processes[i].MainWindowTitle.Equals("myFile.txt - Notepad"))
                {
                    Console.WriteLine("The file myFile is Open!");
                }
            }
            Console.ReadLine();
