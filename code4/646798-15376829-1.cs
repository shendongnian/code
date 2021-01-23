    public void Demo()
    {
        var myInstance = Activator.CreateInstance((new Person()).GetType());
        Console.WriteLine(Test(myInstance));
    }
    private string Test(object x) //redirect the call to the right method
    {
        if (x is Person)
            return Test(x as Person);
        else
            return Test(x as Organization);
    }
    private string Test(Person x) { return string.Format("Person - {0}", x.ToString()); } //this is what you were hoping for
    private string Test(Organization x) { return string.Format("Org - {0}", x.ToString()); }
