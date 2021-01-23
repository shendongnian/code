    radioMale.DataBindings.Add("Checked", 
        new ComparisonBinder<ConfigClass, GenderEnum>(config, c => c.Gender, GenderEnum.Male), 
        "Value");
    radioFemale.DataBindings.Add("Checked", 
        new ComparisonBinder<ConfigClass, GenderEnum>(config, c => c.Gender, GenderEnum.Female),
        "Value");
