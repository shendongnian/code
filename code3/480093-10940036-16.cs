    public void ServiceMethod(IStatus status)
    {
        switch (status.GetKey())
        {
            case (string)MasterStructA.OptionB:
                DoSomething();
        }
    }
