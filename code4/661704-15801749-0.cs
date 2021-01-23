    public class Whatever
    {
        public int SkuNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    [WebMethod]
    public void TakeList(List<Whatever> theList)
    {
        foreach (var w in theList)
        {
        }
    }
