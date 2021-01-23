    var selector = new Selector<Person>().Add
    (
        Selector<Person>.Get(m => m.Address).Add
        (
            Selector<Address>.Get(x => x.Place),
            Selector<Address>.Get(x => x.ParentName).Add
            (
                Selector<Name>.Get(x => x.Id),
                Selector<Name>.Get(x => x.FirstName),
                Selector<Name>.Get(x => x.Surname)
            )
        ), 
        Selector<Person>.Get(m => m.Name).Add
        (
            Selector<Name>.Get(x => x.Id),
            Selector<Name>.Get(x => x.FirstName),
            Selector<Name>.Get(x => x.Surname)
        ),
        Selector<Person>.Get(m => m.Age)
    );
