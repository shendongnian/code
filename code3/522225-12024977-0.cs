    private string foo;
    public Bar()
    {
        foo = "default"; // initialize without calling setter
    }
    public string Foo
    {
        set
        {
            foo = value;
            // setter registers that property has changed
        }
    }
