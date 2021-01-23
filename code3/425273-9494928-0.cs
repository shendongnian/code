    class Family
    {
        ICollection<Person> Children { get; set; }
    }
    int GetAverageNumberOfChildren(IEnumerable<Family> families)
    {
        return families.Sum(f => f.Children.Count) / families.Count();
    }
    void SomeMethod(IEnumerable<Family> families)
    {
        int averageNumberOfChildren = GetAverageNumberOfChildren(families);
        //...
    }
