    public ActionResult Create(Person p)
    {
        p.ValidatePhoneNumber( person => person.HomePhone );
                    if( ModelState.IsValid )
                    ....
    }
