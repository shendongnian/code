            // Any IP Address
            var Value = "192.168.0.55"; 
            var Pattern = new string[]
            {
                "^",            // Start of string
                "[0-9]{1,3}.",  // Between 1 and 3 characters of 0-9 and a period
                "[0-9]{1,3}.",
                "[0-9]{1,3}.",
                "[0-9]{1,3}",   // Same as before, except no period
                "$",            // End of string
            };
            // Evaluates to true 
            var Match = Regex.IsMatch(Value, string.Join(string.Empty, Pattern));
