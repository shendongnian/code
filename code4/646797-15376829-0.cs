    public void Demo()
    {
        var myInstance = Activator.CreateInstance((new Person()).GetType());
        Console.WriteLine(Test(myInstance));
    }
    private string Test(object x) //this is the method being called
    { 
        return string.Format("Object - {0}", x.ToString()); 
    }
    private string Test(Person x) //this is what you were hoping for
    { 
        return string.Format("Person - {0}", x.ToString()); 
    }
    private string Test(Organization x) 
    { 
        return string.Format("Org - {0}", x.ToString()); 
    }
