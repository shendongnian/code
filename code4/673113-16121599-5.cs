    private int age;
    public int Age
    {
        get
        { 
            return age; 
        }
        set
        {
            SetProperty(() => age, value);
        }
    }
