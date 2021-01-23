    string stVal="aaaa\r\naaab\r\naaab\r\naaac";
    string delimiter = "\r\n";
    Console.WriteLine(RemoveFirstMatch(stVal, "aaaa", delimiter) + "\n-------------");
    Console.WriteLine(RemoveFirstMatch(stVal, "aaab", delimiter) + "\n-------------");
    Console.WriteLine(RemoveFirstMatch(stVal, "aaac", delimiter) + "\n-------------");
