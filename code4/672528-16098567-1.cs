    public void StudentDetailInput()
    {
        const int startpoint = 2;
        string[] takeinput = new string[11];
        for (int x = 0; x < takeinput.Length; x++)
        {
            Console.SetCursorPosition(30, startpoint + x);
            takeinput[x] = Console.ReadLine();
        }
    }
