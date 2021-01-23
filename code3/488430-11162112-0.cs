    public MyGeneric<T2> ToOtherType<T2>()
    {
        if (typeof(T2).IsAssignableFrom(typeof(T)))
        {
            // todo: get the object
            return null;
        }
        else
            throw new ArgumentException();
    }
            new MyGeneric<Dog>().ToOtherType<Animal>(),
            new MyInheritedGeneric<Cat>().ToOtherType<Animal>()
