            Regex _r = new Regex("<a (.+?)>");
            foreach (Match m in _r.Matches(text))
            {
                string Link = m.Groups[0].Value;
                Console.WriteLine(m.Groups[0].Value);
                Console.ReadLine();
                // Iterate through all matches
                if (!Link.Contains("target"))
                {
                    // If match does not contain "target", replace.
                    text = text.Replace(Link, Link.Substring(0, Link.Length - 1) + " target=\"_parent\">");
                }
            }
