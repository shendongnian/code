    private void writeLine(String s)
    {
        #if DEBUG
            Debug.WriteLine(s);
        #else
            Console.WriteLine(s);
        #endif
    }
