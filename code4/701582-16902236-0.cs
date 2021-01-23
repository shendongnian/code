    public void GetData()
    {
        Foo foo = bar.GetData();
    
        while (foo == null)
        {
            bar.addItem("Test");
            foo = bar.GetData();
        }
    }
