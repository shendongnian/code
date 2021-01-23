    public Boolean this[Guid personGuid]
    {
       get {
          Person person = GetPersonByGuid(personGuid);
          return person.IsSelected;
       }
       set {
          Person person = GetPersonByGuid(personGuid);
          person.IsSelected = value;
       }
    }
