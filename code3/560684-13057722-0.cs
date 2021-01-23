    protected void Process1(List<SomeClass> mylist)
    {
        foreach (var item in mylist.Where(item => SomeClass.Validate(item))
        {
            DoStuff(item); 
            DoMore(item); 
            DoEven(item);
        }
    }
    
    protected void Process2(List<SomeClass> mylist)
    {
        foreach (var item in mylist.Where(item => item.Value != 0 && SomeClass.Validate(item))
        { 
            DoStuff(item);
            DoMore(item);
            DoEven(item); 
        }
    }
