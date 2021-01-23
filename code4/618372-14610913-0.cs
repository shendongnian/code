    public IEnumerable<NamePlace> GetSomeData(Func<Name,Place, bool> condition)
    {
      var temp = from Name in Names
                 from Place in Places
                 where condition(Name,Place)
                 select new NamePlace {
                      field1 = Name.name;
                      field2 = Place.name;
                 };
      return temp;
    }
