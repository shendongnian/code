    public bool GetElectricalStatus(string printName)
    {
        var query =
            from row in singulationOne.Table.AsEnumerable()
            where row.Field<string>("print") == printName
            // using the nullable implementation
            let electrical = ParseInt32(row.Field<string>("electrical"))
            where electrical != null
            where electrical == 19 || electrical >= 100 && electrical <= 135
            select row;
        return !query.Any();
    }
