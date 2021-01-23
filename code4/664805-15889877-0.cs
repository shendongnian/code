    // In Field
    public virtual void Function()
    {
        if (this is StartField)
        {
            Debug.WriteLine("StartField running base function!");
        }
        //Actual logic here. 
    }
    // In StartField
    public override void Function()
    {
        Debug.WriteLine("StartField function");
        //Different logic then the base function
    }
