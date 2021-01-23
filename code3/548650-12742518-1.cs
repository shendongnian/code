    public void DoSomething(Person p)
    {
        Employee e = p as Employee;
        if(e != null) DoSomething(e);
        else {
            Customer c = p as Customer;
            if(c != null) DoSomething(c);
        }
    }
