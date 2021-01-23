    protected void Process1(List<SomeClass> mylist)
    {
        foreach (var item in mylist)
        { 
            if (!SomeClass.Validate(item))        
                continue;
            
            DoStuff(item);
            DoMore(item);
            DoEven(item); 
        }
    }
    protected void Process2(List<SomeClass> mylist)
    {
        Process1(myList.Where(item => item.Value != 0));
    }
