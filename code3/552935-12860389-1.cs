            string input = "goal0=1234.4334abc12423423";
            string input = "goal0=1234.4334abc12423423";
            input = input.Substring(input.IndexOf('=') + 1);
            IEnumerable<char> stringQuery2 = input.TakeWhile(c => Char.IsDigit(c) || c=='.');
            string result = string.Empty;
            foreach (char c in stringQuery2)
                result += c;
            double dResult = double.Parse(result);
