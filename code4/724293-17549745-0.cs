    public MyViewModel MyVM
    {
        get 
        { 
            return SimpleIoc.Default.GetInstance<MyViewModel>();
        }
    }
