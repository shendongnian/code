            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            // Match the regular expression pattern against a text string.
            Match m = r.Match(input);
            if (m != null)
            {
                Debug.WriteLine(m.Groups[1].Value);
                Debug.WriteLine(m.Groups[2].Value);
                Debug.WriteLine(m.Groups[3].Value);
            }
