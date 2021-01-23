    public void Test()
    {
        StreamReader sr = new StreamReader("Whatever");
        foreach (var line in ReadLines(sr))
        {
            if (line.Text == "SomeSpecialValue")
                doSomethingWith(line.Text, line.Number);
        }
    }
