    bool wasOk = true;
    foreach (MyObject obj in MyObjects)
    {
        if (obj.MyFirstProperty == someBadValue)
        {
            wasOk = false;
            break;
        }
        if (obj.MySecondProperty == someOtherBadValue)
        {
            wasOk = false;
            break;
        }
    }
