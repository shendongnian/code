    bool success = false;
    try
    {
        …
        success = true;
    }
    catch (…)
    {
        …
    }
    …
    finally
    {
        if (!success)
        {
            DoSomething();
        }
    }
