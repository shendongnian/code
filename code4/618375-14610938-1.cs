    private IEnumerable<NamePlace> GetSomeDataHelper(Func<Name, Place, bool> filter)
    {
      var query = from name in Names
                 from place in Places
                 where filter(name, place)
                 select new NamePlace {
                      field1 = name.name,
                      field2 = place.name,
                 };
      return query;
    }
    
    public IEnumerable<NamePlace> GetSomeData1(int num1, int num2)
    {
        return GetSomeDataHelper((name, place) => name.id == num1 && place.id = num2);
    }
