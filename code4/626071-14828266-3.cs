    string s = "foo"; // create instance with foo
    string t = s;     // copy reference, contents aren't changed
    char[] ch = s.ToCharArray(); // attempt to access underlying contents
    ch[0] = 'b';      // attempts to change the underlying contents
    Console.WriteLine(t); // 'boo'?
