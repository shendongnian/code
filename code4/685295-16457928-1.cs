    static void Main()
    {
        var s = new Struct(1);
        Debug.Assert(s.Value == 1, "Read-only field is 1");
        s.Value = 2;
        Debug.Assert(s.Value == 2, "Read-only field written!");
    }
