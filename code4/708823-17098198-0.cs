      public static string Substitute(string s)
                {
                    var abbrevs = new Dictionary<string, string>();
                    abbrevs.Add("OFC", "OFFICE");
                    abbrevs.Add("ST", "STREET");
                    abbrevs.Add("ST.", "STREET");
                    if (abbrevs.ContainsKey(s)) return abbrevs[s];
                    return SubstituteWordNumbersForNumerics(s);            
                }
        
                public static string ToNormalAddressFormat(string address)
                {
                    return address.Split(' ').ToList().Select(Substitute).Aggregate((x, y) => x + " " + y);
                }
