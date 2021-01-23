    var test = new ValidatorList();
    test.Add(
                new RequiredValidator()
                    {
                        PropertyName="CustRef",
                        Next = new AsciiValidator()
                    });            
    test.Add(
                new RequiredValidator()
                    {
                        PropertyName="CurrencyIndicator",
                            Next = new StringLengthValidator(){
                                MinLength=3,
                                MaxLength = 10
                            }
                    });
