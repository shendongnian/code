     _lstr.Add("AA");
     _lstr.Add("BB");
     _lstr.Add("1");
     _lstr.Add("7");
     _lstr.Add("2");
     _lstr.Add("5");
     _lstr.Add("CC");
     _lstr.Add("9");
     int num = 0; int sum  = 0;
     foreach(string s in _lstr)
     {
        bool result = Int32.TryParse(s, out num);
        Console.WriteLine("TryParse:" + result + " num=" + num);
     }
    TryParse:False num=0
    TryParse:False num=0
    TryParse:True num=1
    TryParse:True num=7
    TryParse:True num=2
    TryParse:True num=5
    TryParse:False num=0
    TryParse:True num=9
