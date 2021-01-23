     var stringsWithoutNumbers = new List<string>();
        foreach (var str in _words)
        {
            int n;
            bool isNumeric = int.TryParse("123", out n);
            if (!isNumeric)
            {
                stringsWithoutNumbers.Add(str);
            }
        }
