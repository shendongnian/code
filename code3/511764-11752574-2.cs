    public static void TestSB()
    {
        var testValue = "{{ \"id\" : \"myID\", \"Name\" : \"MyDisplayName\", \"description\" : \"A, MyDescription\", }\"hasOverview\" : true, \"hasDescription\" : true, }";
        var sb = new StringBuilder();
        sb.Append(testValue);
        var sbToString = sb.ToString();
        // Prints true
        Console.WriteLine(sbToString.Equals(testValue));
    }
