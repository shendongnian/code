    public void GetData()
    {
        Foo foo;
        do
        {
            foo = bar.GetData();
            if (foo == null)
            {
                bar.addItem("Test");
            }
        } while (foo == null);
    }
