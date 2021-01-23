    public Person ReadPerson(string[] personLine)
    {
        Person p = new Person();
        p.Name = personLine[0];
        p.Age = Convert.ToInt16(personLine[1]);
        p.Score = Convert.ToDouble(personLine[2]);
        p.PlotArea = Convert.ToInt16(personLine[3]);
        p.ForecastConsumption = Convert.ToDouble(personLine[4]);
        p.Postcode = personLine[5];
        p.PropertyType = personLine[6];
        p.Bedrooms = Convert.ToInt16(personLine[7]);
        p.Occupancy = Convert.ToInt16(personLine[8]);
    }
