                static Regex rex = new Regex("\\P{L}");
                public static string RemoveNonUnicodeLetters2(string input)
                {
                    var result = rex.Replace(input,m => "");
                    return result;
                }
