                // VS 2012 Ultimate
                // 
                Regex r = new Regex(".def.");
                Match mtch = r.Match("abcdefghijklmnopqrstuvwxyz", 0);
                string a, b, c, d;
                for (int i = 0; i < int.MaxValue; i++)
                {
                   a = mtch.Value;                  // 1.4%
                   b = mtch.ToString();             // 33.2%
                   c = mtch.Groups[0].Value;        // 15.3%
                   d = mtch.Groups[0].ToString();   // 44.1%
                }
