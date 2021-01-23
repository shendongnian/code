    string[] strA = new string[10]
    {
        "Board1",
        "Messages Transmitted75877814",
        "ISR Count682900312",
        "Bus Errors0",
        "Data Errors0",
        "Receive Timeouts0",
        "TX Q Overflows0",
        "No Handler Failures0",
        "Driver Failures0",
        "Spurious ISRs0"
    };
    Dictionary<string, int> list = new Dictionary<string, int>();
    foreach (var item in strA)
    {
        // this Regex matches any digit one or more times so it picks
        // up all of the digits on the end of the string
        var match = Regex.Match(item, @"\d+");
        // this code will substring out the first part and parse the second as an int
        list.Add(item.Substring(0, match.Index), int.Parse(match.Value));
    }
