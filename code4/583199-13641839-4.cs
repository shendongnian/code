        public static decimal[] intRemover (string input)
        {
            int n=0;
            MatchCollection matches=Regex.Matches(input,@"[+-]?\d+(\.\d+)?");
            decimal[] decimalarray = new decimal[matches.Count()];
            foreach (Match m in matches) 
            {
                    intarray [n] = decimal.Parse (m.Value);
                    n++;
            }
            return decimalarray;
        }
