       string c = new string(new char[] {'a','b','c'});
       string d = new string(new char[] {'a','b','c'});
    
       Console.WriteLine(c == d); // true
    
       object k = c;
       object m = d;
    
       Console.WriteLine(k.Equals(m)); //true
    
       Console.WriteLine(k == m); // false
