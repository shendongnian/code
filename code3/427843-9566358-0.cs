    [WebMethod]
    public int CalculateSum(List<int> listInt)
    {
        int sum = listInt.Sum();
        return sum; // error under sum on this line
    
    }
