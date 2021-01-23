    _DbContext.Entry<Person>(myPerson)
              .Collection(i => i.Adresses) // navigation property for Person
              .Query()
              .Include("AddressType")        // navigation property for Address
              .OrderBy(i => i.Name)
              .ThenBy(i => i.AddressType.AddressTypeName) // just an example
              .Select(i => new someClass
              {
                  SoomeField1 = i.SomeField1,
                  ...
              })
              .ToList()
              .ForEach(i => SomeList.Add(i)); // SomeList is a List<T>
