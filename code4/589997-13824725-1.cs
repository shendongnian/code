            string srVariable = "32 ab d32";
            List<string> lstAllowedCharacters = new List<string> { "a", "b", "c", "2", " " };
            srVariable = Regex.Replace(srVariable, "[^" + string.Join("", lstAllowedCharacters) + "]", delegate(Match m)
            {
                if (!m.Success) { return m.Value; }
                return " ";
            });
            Console.WriteLine(srVariable);
