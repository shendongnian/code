    string s = "foo"; // create instance with foo
    string t = s;     // copy reference, contents aren't changed
    char[] ch = s.ToCharArray(); // access underlying contents. Contents are still not changed
    ch[0] = 'b';      // change underlying contents
    Console.WriteLine(t); // 'boo'?
