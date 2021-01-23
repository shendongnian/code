    public static void SO_13254153_Question()
    {
        string x = "\u002D\u30A2";  // or just "-ア" if charset allows
        string y = "\u3042";        // or just "あ" if charset allows        
        var invariantComparer = new WorkAroundStringComparer();
        var japaneseComparer = new WorkAroundStringComparer(new System.Globalization.CultureInfo("ja-JP", false));
        Console.WriteLine(x.CompareTo(y));  // positive one
        Console.WriteLine(y.CompareTo(x));  // positive one
        Console.WriteLine(invariantComparer.Compare(x, y));  // negative one
        Console.WriteLine(invariantComparer.Compare(y, x));  // positive one
        Console.WriteLine(japaneseComparer.Compare(x, y));  // negative one
        Console.WriteLine(japaneseComparer.Compare(y, x));  // positive one
    }
