    struct CustomerStruct
    {
      char[100] FirstName;
      char[100] LastName;
    }
    // one to one, nested, relationship, seems redudant,
    // but required
    Class CustomerClass
    {
      CustomerStruct Data;
      public void Store(Stream Destination) { ... }
      public void Load(Stream Source) { ... }
      public void CopyTo(CustomerStruct Destination) { ... }
      public void CopyFrom(CustomerStruct Source) { ... }
    }
