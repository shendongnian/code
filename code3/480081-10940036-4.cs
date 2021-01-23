    public void ServiceMethod(IFakeEnumA option)
    {
        switch (option.GetValue())
        {
            case MasterStructA.OptionB.Value:
                DoSomething();
        }
    }
