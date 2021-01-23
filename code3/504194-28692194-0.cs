    string[] doubleStrings = {"hello", "0.123", "0,123"};
            double localCultreResult;
            foreach (var doubleString in doubleStrings)
            {
                double.TryParse(doubleString, NumberStyles.Any, CultureInfo.CurrentCulture, out localCultreResult);
                Console.WriteLine(string.Format("Local culture results for the parsing of {0} is {1}",doubleString,localCultreResult));
            }
            double invariantCultureResult;
            foreach (var doubleString in doubleStrings)
            {
                double.TryParse(doubleString, NumberStyles.Any, CultureInfo.InvariantCulture, out invariantCultureResult);
                Console.WriteLine(string.Format("Invariant culture results for the parsing of {0} is {1}", doubleString, invariantCultureResult));
            }
