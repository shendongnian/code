    radioMale.DataBindings.Add("Checked", 
        new ComparisonBinder<ConfigClass>(config, c => c.Gender, GenderEnum.Male), 
        "Value");
    radioFemale.DataBindings.Add("Checked", 
        new ComparisonBinder<ConfigClass>(config, c => c.Gender, GenderEnum.Female),
        "Value");
