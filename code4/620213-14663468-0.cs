    string mystring = "1. JoshTestLowdop 192";
    int start = mystring.IndexOf(' ');
    string FirstNO = mystring.Substring(0, start);
    string Name = mystring.Substring(start + 1, mystring.LastIndexOf(' ') - (start + 1));
    string ID = mystring.Substring(mystring.LastIndexOf(' ') + 1);
    Console.WriteLine(FirstNO);
    Console.WriteLine(Name);
    Console.WriteLine(ID);
    // outputs:
    1.
    JoshTestLowdop
    192
