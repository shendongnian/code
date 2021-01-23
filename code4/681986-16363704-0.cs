    public event Action MyAction
    {
        add 
        { 
             return SomeLibraryClass.StaticAction += value;
        }
        remove
        { 
             return SomeLibraryClass.StaticAction -= value;
        }
    }  
