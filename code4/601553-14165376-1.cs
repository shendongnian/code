    TestAttribute t = new TestAttribute()
    {
        MyDateTime = DateTime.Now,
        MyFloat = 1.2345678f,
        MyFloat2 = 1.2345678f,
        MyInt = 5
    };
    Console.WriteLine(t.FormatProperty(x => x.MyDateTime));
    Console.WriteLine(t.FormatProperty(x => x.MyFloat));
    Console.WriteLine(t.FormatProperty(x => x.MyFloat2));
    Console.WriteLine(t.FormatProperty(x => x.MyInt));
