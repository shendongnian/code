    public void GetData()
    {
        Foo foo = bar.GetData();
        if (foo == null)
        {
            bar.addItem("Test");
            foo = bar.GetData();
            Debug.Assert(foo != null, "Hey, I thought that would give me a value!");
        }
        // do something with foo
    }
