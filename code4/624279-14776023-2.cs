        public static void Main()
        {
            new Task(ThisWillExecuteOnAnotherThread);
        }
        public static void ThisWillExecuteOnAnotherThread()
        {
            using (FileStream fileStream = File.OpenRead("data.txt"))
            using (StreamReader reader = new StreamReader(fileStream))
            {
                // This will read a single line of text
                String line = reader.ReadLine();
            }
        }
