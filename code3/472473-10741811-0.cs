    public TypeOne ConvertToTypeTwo (TypeTwo typeTwo)
    {
        var typeOne = new TypeOne();
        typeOne.property1 = typeTwo.property1; //no problem on simple types
        typeOne.SubType = ConvertToTypeTwo(typeTwo.SubType); //problem!
    }
    
    public TypeOneSubtype ConvertToTypeTwo(TypeTwoSubType typeTwo)
    {
        var subOne = new TypeOneSubType;
        subOne.property1 = typeTwo.property1;
        // etc.
    }
