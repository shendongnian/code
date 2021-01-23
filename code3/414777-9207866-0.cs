    public IEnumerable<Localisation> GetByFiltre(Func<IEnumerable<localisation>, IEnumerable<localisation>> whereClause)
    {
        /*
        filter has the value of an operator:
        >
        ==
        !=
        >=
        <=
        */
    
        DateTime dt = Convert.ToDateTime(valeurDate1);
    
        var mod = whereClause(new GpsContext().Locals);
    }
