    static void Main(string[] args)
    {
        var Customer = new { FirstName = "John", LastName = "Doe" };
        var customerList = MakeList(Customer);
        
        customerList.Add(new { FirstName = "Bill", LastName = "Smith" });
    }
    public static List<T> MakeList<T>(T itemOftype)
    {
        List<T> newList = new List<T>();
        return newList;
    }
