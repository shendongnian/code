    MyObject a = new MyObject() { Value = 4 };
    MyObject b = new MyObject() { Value = 5 };
    MyObject c = new MyObject() { Value = 6 };
    List<MyObject> tmp = new List<MyObject>();
    
    tmp.Add(a);
    tmp.Add(b);
    tmp.Add(c);
    
    tmp[0].Value = 16;
    tmp[1].Value = 3;
    tmp[2].Value = 1000;
    
    Console.Writeline(tmp[0].Value.ToString() + " " + a.Value.ToString()); // 16 16
    Console.Writeline(tmp[1].Value.ToString() + " " + b.Value.ToString()); // 3 3
    Console.Writeline(tmp[2].Value.ToString() + " " + c.Value.ToString()); // 1000 1000
