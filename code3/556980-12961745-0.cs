    Animal a = new Cat();
    
    try
    {
        Dog d = (Dog)a;
    }
    catch (InvalidCastException)
    {
        try
        {
            Cat c = (Cat)a;
        }
        catch (InvalidCastException)
        {
        }
    }
