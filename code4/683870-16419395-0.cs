    static void Main()
    {
        var data = FakeRetrieveFromRepo();
        // order here is "One", "Two", "Three"
        data = data.OrderBy(row => row.Option.Value).ToList();
        // order here is "Two", "Three", "One"
    }
    private static List<MyModel> FakeRetrieveFromRepo()
    {
        return new List<MyModel>
        {
            new MyModel { Option = new MyOption {
               Value = 121370002, Description = "One" }},
            new MyModel { Option = new MyOption {
               Value = 121370000, Description = "Two" }},
            new MyModel { Option = new MyOption {
               Value = 121370001, Description = "Three" }},
        };
    }
