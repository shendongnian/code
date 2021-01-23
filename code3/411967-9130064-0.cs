        string a = "quickbrownfoxjumpsoverthelazydog";
        DateTime t1 = DateTime.Now;
        for (int i = 0; i != 10000000; i++) {
            var b = a.Replace('o', 'b');
            if (b.Length == 0) {
                break;
            }
        }
        DateTime t2 = DateTime.Now;
        for (int i = 0; i != 10000000; i++) {
            var b = a.Replace("o", "b");
            if (b.Length == 0) {
                break;
            }
        }
        DateTime te = DateTime.Now;
        Console.WriteLine("{0} {1}", t2-t1, te-t2);
