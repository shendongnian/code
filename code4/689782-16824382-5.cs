    var selector = new Selector<Person>();
    selector.AddToConcatRest(m => m.Age).AddToAddToItsInner(m => m.Address)
                .Add(m => m.Place).AddToAddToItsInner(m => m.ParentName)
                    .Add(m => m.Id).Add(m => m.FirstName).Add(m => m.Surname);
    selector.AddToAddToItsInner(m => m.Name)
                .Add(m => m.Id).Add(m => m.FirstName).Add(m => m.Surname);
