    static void Main()
    {
        object obj = Evil();
        int i = (int)obj; // 0
        int j = int.Parse(obj.ToString()); // 42
    }
