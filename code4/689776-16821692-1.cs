    var selector = new Selector<Person>
    {
        new Selector<Person>
        {
            m => m.Address
        }.InnerAdd
        (
            new Selector<Address>
            {
                n => n.Place
            },
            new Selector<Address>
            {
                n => n.ParentName
            }.InnerAdd
            (
                new Selector<Name>
                {
                    o => o.Id,
                    o => o.FirstName,
                    o => o.Surname
                }
            )
        ),
        new Selector<Person>
        {
            m => m.Name
        }.InnerAdd
        (
            new Selector<Name>
            {
                n => n.Id,
                n => n.FirstName,
                n => n.Surname
            }
        ),
        m => m.Age
    };
