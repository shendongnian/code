    public void GetData()
    {
        Foo foo;    
        while ((foo = bar.GetData()) == null)
            bar.addItem("Test");
    }
