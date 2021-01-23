    public void Access(Foo foo)
    {
        if (GetType() == foo.GetType) //Duh...
        {
             AccessIfSameImplementation(foo);
        }
        else
        {
             AccessIfDifferentImplementation(foo);
        }
    }
