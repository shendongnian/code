    protected void Process1(List<SomeClass> myList)
    {
        myList.Where(item => SomeClass.Validate(item)).ToList()
            .ForEach(item =>
            {
                DoStuff(item);
                DoMore(item);
                DoEven(item);
            });
    }
    protected void Process2(List<SomeClass> myList)
    {
        myList.Where(item => SomeClass.Validate(item) && item.Value != 0).ToList()
            .ForEach(item =>
            {
                DoStuff(item);
                DoMore(item);
                DoEven(item);
            });
    }
