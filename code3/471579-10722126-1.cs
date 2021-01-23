    try
    {
       DoSomething();
       ok = true;
    }
    catch(FirstExcetionType e1)
    {
        //do something
    }
    catch(SecondExcetionType e2)
    {
        //do something
    }
    catch(Exception e3)
    {
        //do something
    }
    finally
    {
        if(!ok)Rollback();
    }
