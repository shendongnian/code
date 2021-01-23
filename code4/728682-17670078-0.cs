            string[] numbers = new string[] { "+46703897733","+46733457773","46733457773"};
             string regexPattern = @"^\+(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$";
            Regex r = new Regex(regexPattern);
            
            foreach(string s in numbers)
            {
                if (r.Match(s).Success)
                {
                   //"+46703897733","+46733457773" are valid in this case
                    Console.WriteLine("Match");
                }
            }
