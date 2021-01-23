    try
    {
        ControlTypeEtc ctrl2 = (ControlTypeEtc)ctrl;
        ctrl2.SomeMethod();
    }
    catch (InvalidCastException e)
    {
    }
