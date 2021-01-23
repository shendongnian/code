        public bool IsValidNumber(string input)
        {
            int val = 0;
            return int.TryParse(input.Trim(), NumberStyles.Any, null, out val);
        }
    "$100,000" = true
    "100.002" = true
    "1000,44j" = false
    etc.
