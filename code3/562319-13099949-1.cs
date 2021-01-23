    static public void Main()
    {
        string username = "Matthew";
        string currentLine;
        do
        {
            currentLine = Console.ReadLine();
            if (currentLine.Equals("restart"))
            {
                Console.Clear();
            }
            if (currentLine.StartsWith("my name is"))
            {
                username = currentLine.Replace("my name is ", "");
            }
            if (currentLine.Equals("my name"))
            {
                Console.WriteLine("Your name is {0}", username);
            }
        }
        while (!currentLine.Equals("exit"))
    }
