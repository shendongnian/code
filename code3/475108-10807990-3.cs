    class Root
    {
        Company Company { get; set; }
        List<Model> ModelList { get; set; }
    }
    class Company
    {
        string Location { get; set; }
        string Name { get; set; }
    }
    class Model
    {
        string Name { get; set; }
        int Value { get; set; }
    }
