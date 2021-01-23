    private Dictionary<string, string> _namesById;
    public Dictionary<string, string> NamesById
    {
        set { _namesById = value; }
        get
        {
            if (_namesById == null)
            {
                _namesById = new Dictionary<string, string>();
                
                foreach (var person in XmlPeople)
                {
                     _namesById.Add(person.Id, person.Name);
                }
            }
            return _namesById;
        }
    }
