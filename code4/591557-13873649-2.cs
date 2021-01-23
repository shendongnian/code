    class Apple { }
    class Pear { }
    void Handle(object what)
    {
        // either
        if (what is Apple) {}
        else if (what is Pear) {}
        // or
        dynamic x = what;
        x.LetsHopeThisMethodExists();
        // or
        what.GetType().GetMethod('lorem').Invoke(what, null);
    }
