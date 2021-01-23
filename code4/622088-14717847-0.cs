    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    
    class MultiRegex {
    
        static String Replace(String text, Regex[] expressions,
                String[] replacements, int start=0)
        {
            // Try matching each regex; save the first match
            Match firstMatch = null;
            int firstMatchingExpressionIndex = -1;
            for (int i = 0; i < expressions.Length; i++) {
                Regex r = expressions[i];
                Match m = r.Match(text, start);
                if (m.Success
                        && (firstMatch == null || m.Index < firstMatch.Index))
                {
                    firstMatch = m;
                    firstMatchingExpressionIndex = i;
                }
            }
    
            if (firstMatch == null) {
                /* No matches anywhere */
                return text;
            }
    
            // Replace text, then recurse
            String newText = text.Substring(0, firstMatch.Index)
                + replacements[firstMatchingExpressionIndex]
                + text.Substring(firstMatch.Index + firstMatch.Length);
            return Replace(newText, expressions, replacements,
                    start + replacements[firstMatchingExpressionIndex].Length);
        }
    
        public static void Main() {
    
            Regex[] expressions = new Regex[]
            {
                new Regex("a"), //replaced by ab
                new Regex("b") //replaced by c
            };
    
            string[] replacements = new string[]
            {
                "ab",
                "c"
            };
    
            string original = "a b c";
            Console.WriteLine(
                    Replace(original, expressions, replacements));
    
            // Should be "baz foo bar"
            Console.WriteLine(Replace("foo bar baz",
                        new Regex[] { new Regex("bar"), new Regex("baz"),
                            new Regex("foo") },
                        new String[] { "foo", "bar", "baz" }));
        }
    }
