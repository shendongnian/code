    static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                using (StreamWriter sw = new StreamWriter(args[1]))
                {
                    using (StreamReader sr = new StreamReader(args[0]))
                    {
                        String line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            int index = 0;
                            int oldIndex = 0;
                            string dateTime = null;
                            string action = null;
                            string task = null;
                            string details = null;
                            index = line.IndexOf(' ', oldIndex);
                            dateTime = line.Substring(oldIndex, index - oldIndex);
                            oldIndex = index + 1;
                            index = line.IndexOf(' ', oldIndex);
                            action = line.Substring(oldIndex, index - oldIndex);
                            oldIndex = index + 1;
                            index = line.IndexOf(':', oldIndex);
                            task = line.Substring(oldIndex, index - oldIndex);
                            oldIndex = index + 1;
                            details = line.Substring(oldIndex + 1);
                            sw.WriteLine("\"{0}\",\"{1}\",\"{2}\",\"{3}\"", dateTime, action, task, details);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Usage: program <input> <output>");
            }
        }
