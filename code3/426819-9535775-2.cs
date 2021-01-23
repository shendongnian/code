    public IEnumerable<decimal> ExtractNumbers(string s)
    {                                                  // For s = "CC77X1722X12"
        string[] nums = s.Substring(2).Split('X');     // nums = ["77", "1722", "12"];
        return nums.Select(num => decimal.Parse(num)); // returns [77, 1722, 12]
    }
