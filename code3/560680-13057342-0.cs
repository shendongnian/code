    protected void Process1(List<SomeClass> myList)
    {
        myList.Where(item => SomeClass.Validate(item))
            .ForEach(item =>
            {
                DoStuff(item);
                DoMore(item);
                DoEven(item);
            });
    }
    protected void Process2(List<SomeClass> myList)
    {
        myList.Where(item => SomeClass.Validate(item) && item.Value != 0)
            .ForEach(item =>
            {
                DoStuff(item);
                DoMore(item);
                DoEven(item);
            });
    }
