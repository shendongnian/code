    const string DefaultRuleset = "Default";
    const string AlternativeRuleset = "Alternative";
    var builder = new ValidationConfigurationBuilder();
    builder.RegisterDefaultRulesetForAllTypes(DefaultRuleset);
    builder.ForType<Person>()
        .ForProperty(p => p.Age)
            .AddRangeValidator(new RangeData<int>()
            {
                LowerBound = 18,
                MessageTemplate = "This is an adult system",
            })
        .ForProperty(p => p.FirstName)
            .AddValidator(new NotNullValidator())
            .AddValidator(new StringLengthValidatorData()
            {
                LowerBound = 1,
                LowerBoundType = RangeBoundaryType.Inclusive,
                UpperBound = 100,
                UpperBoundType = RangeBoundaryType.Inclusive
            })
        .ForProperty(p => p.LastName)
            .AddValidator(new NotNullValidator())
        .ForProperty(p => p.Friends)
            .AddValidator(new ObjectCollectionValidator());
    builder.ForType<Person>().ForRuleset(AlternativeRuleset)
        .ForProperty(p => p.FirstName)
            .AddValidator(new NotNullValidator())
            .AddValidator(new StringLengthValidatorData()
            {
                LowerBound = 1,
                LowerBoundType = RangeBoundaryType.Inclusive,
                UpperBound = 10,
                UpperBoundType = RangeBoundaryType.Inclusive
            });
