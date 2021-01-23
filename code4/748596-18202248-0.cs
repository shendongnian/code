     string[] lines = File.ReadAllLines(Path.Combine(Application.StartupPath, "test.txt"));
            foreach (string s in lines)
            {
                if (s.ToLowerInvariant().Contains("generatednumber"))
                {
                    string temp = s.Substring(s.ToLowerInvariant().IndexOf("generatednumber"));
                    temp = temp.Substring(temp.IndexOf("\"") + 1);
                    temp = temp.Substring(0,temp.IndexOf("\""));
                    int yournumber;
                    if (int.TryParse(temp, out yournumber))
                    {
                        Console.WriteLine("Generated Number = ", yournumber);
                    }
                }
            }
