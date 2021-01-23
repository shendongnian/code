    string input="as8d79asf5.dfdg dg s dgd2011/25klsdsj jdıo84823 jhgfkasfsf 2001/26llkasdjfıo";
            Regex nmRegex = new Regex(@"([\d]+/[\d]+)");
            var matches = nmRegex.Matches(input);
            List<string> matchedStrings = new List<string>();
            for (int i = 0; i < matches.Count; i++)
            {
                var g = matches[i].Groups;
                if (g.Count > 0)
                    matchedStrings.Add(g[1].Value);
            }
