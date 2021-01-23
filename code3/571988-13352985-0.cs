    using System.Linq;
    public List<string> GetUniqueCardNumbers(List<string> cardNumbers)
    {
        // First replace the spaces with empty strings
        return cardNumbers.Select(cc => cc.Replace(" ", ""))
                          .Distinct()
                          .ToList();
    }
