    Match m;
    do
    {
      m = Regex.Match(s, @"\A([\s\S]*)(<(\S+)[^[<>]*>[^<>]*</\3>)([\s\S]*)\Z");
      if (m.Success) {
        s = m.Groups[1].Value + "{0}" + m.Groups[4].Value;
        System.Console.WriteLine("Match: " + m.Groups[2].Value);
      }
    } while (m.Success);
    System.Console.WriteLine("Result: " + s);
