    public void GetData()
    {
        Foo foo = bar.GetData();    
        if (foo == null)
        {
            bar.addItem("Test");
            // following the assumption
            // "once a value has been added to bar then the IF statement will be bypassed"
            // there is no need for another GetData call - bar object is in valid state now
        }
        //Use the bar object
    }
