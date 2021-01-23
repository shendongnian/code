    public string getMaskedInput(string prompt, IConsoleWrapper console)
            {
                string pwd = "";
                ConsoleKeyInfo key;
                do
                {
                    key = console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        pwd = pwd += key.KeyChar;
                        console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && pwd.Length > 0)
                        {
                            pwd = pwd.Substring(0, pwd.Length - 1);
                            console.Write("\b \b");
                        }
                    }
                }
                while (key.Key != ConsoleKey.Enter);
                return pwd;
            }
