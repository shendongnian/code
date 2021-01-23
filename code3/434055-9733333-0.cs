    public void DoSomething()
    {
        try
        {
            SomeCoolOp();
        }
        catch (Exception err)
        {
            throw new CustomException("Tried to allocate some cool stuff", err);
        }
    }
