    public int Value { get; set; }
    public void Foo()
    {
        if (this.Value > 0)   // Read the property and make a decision based on its present value
        {
            // Do something with the property, assuming its value has passed your test.
            // Note that the property's value may have been changed by another thread between the previous line and this one.
            Console.WriteLine(this.Value);
        }
    }
