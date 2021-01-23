        string s = ...
        Match m;
        do
        {
          m = Regex.Match(s, @"\A([\s\S]*)<([^[<>]+)>[^<>]*</\2>([\s\S]*)\Z");
          if (m.Success)
            s = m.Groups[1].Value + "{0}" + m.Groups[3].Value;
        } while (m.Success);
        System.Console.WriteLine(s);
