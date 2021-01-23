            string goal0 = "1234.4334abc12423423";
            IEnumerable<char> stringQuery2 = goal0.TakeWhile(c => Char.IsDigit(c) || c=='.');
            string result = string.Empty;
            foreach (char c in stringQuery2)
                result += c;
            double dResult = double.Parse(result);
