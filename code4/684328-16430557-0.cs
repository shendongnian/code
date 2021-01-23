    string str1 = "blah, blah, May 08, 2012";
    string str2 = "blah blah blah, June 19, 2011";
    
    int splitter = str1.Substring(0, str1.LastIndexOf(',')).LastIndexOf(',');
    
    string newStr1 = str1.Substring(0, splitter);
    string newStr2 = str1.Substring(splitter + 2, str1.Length - (splitter + 2));
    
    Console.WriteLine(newStr1);
    Console.WriteLine(newStr2);
    
    Console.ReadKey();
