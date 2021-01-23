    string t = "1234ABCD-1A-AB";
    string[] tempVar = t.Split('-');
    
    foreach(string s in tempVar)
    {
         Console.WriteLine(s);
    }
    Console.Read();
