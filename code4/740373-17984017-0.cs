    void MyEventHandler(object source, EventArgs e)
    //                                          ^^^
    {
        try
        {
            DoSomething();
        }
        catch (Exception e)
        //              ^^^
        {
            OhNo();
        }
    }
---
    void MyMethod()
    {
        int e = 2.71828;
    //     ^^^
        try
        {
            DoSomething();
        }
        catch (Exception e)
        //              ^^^
        {
            OhNo();
        }
    }
