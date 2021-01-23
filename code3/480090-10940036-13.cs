    public void ServiceMethod(IFakeEnumA option)
    {
        switch (option.GetKey())
        {
            case (string)MasterStructA.OptionB:
                DoSomething();
        }
    }
