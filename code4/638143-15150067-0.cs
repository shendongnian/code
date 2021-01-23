    private static Regex digitsOnly = new Regex(@"[^\d]");
    
            public static string RemoveNonNumbers(string input)
            {
                return digitsOnly.Replace(input, "");
            }
