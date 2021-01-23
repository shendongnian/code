            String s = "abcd,efgh,ijkl";
            var l = new List<string[]>();
            for (int i = 0; i < s.Length; i += 5)
                l.Add(new string[2] { s.Substring(i, 2), s.Substring(i + 2, 2) });
            String[][] sa = l.ToArray();
