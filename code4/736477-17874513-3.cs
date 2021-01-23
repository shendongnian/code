    void Main() {
        var list = new List<string>() { "a", "b", "c" };
        foreach(var item in list) Print(item);
    }
    void Print(string item) { Console.WriteLine(item); }
