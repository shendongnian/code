    class Mapping : Attribute
    {
        public string Map;
        public Mapping(string s)
        {
            Map = s;
        }
    }
    [Mapping("Person")]
    public void getPersonHandler(int id)
    {
        Console.WriteLine("<<<<" + id);
    }
