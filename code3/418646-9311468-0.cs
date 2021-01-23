    //class level declaration (in a console app)
    static List<string> strings;
    static void Loop(string s)
    {
      Console.WriteLine(s);
      strings.Add(s + "!");
    }
