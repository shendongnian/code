    string a = "", b = "b", c = "", d = "d", e = "";
    string lala = string.Join(" / ",
        string.Join("\u0008", new string[] { a, b, c, d, e }).Split(new char[] { '\u0008' }, System.StringSplitOptions.RemoveEmptyEntries)
    );
    System.Console.WriteLine(lala);
