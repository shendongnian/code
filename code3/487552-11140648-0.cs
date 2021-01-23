            Regex curlyThings = new Regex(@"\{0:.*?\}");
            Regex kosherCurlyThings = new Regex(@"\{0:(yy|yyyy|MM|dd|hh|mm|ss)\}");
            MatchCollection matchCollection = curlyThings.Matches("CG{0:yyyy}-{0:MM}-{0:dd}asdf{0:GARBAGE}.csv");
            foreach(Match match in matchCollection)
            {
                if(!kosherCurlyThings.IsMatch(match.Value))
                {
                    Console.WriteLine("{0} isn't kosher!", match.Value);
                }                
            }
