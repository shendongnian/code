    Person p=new Person();
    //p contains the address of the newly allocated person
    change(p);
    //p is passed by value so the address within p would get copied into p1 which is a method parameter of change method
    public void change(Person p1)
    //p1 and p are separate variables containing address of person object
    {
        p1.Name="SO";
        //changes name of p1 and p
        p1=null;
        //this makes p1 null not p since p and p1 are separate copies pointing to person object
    }
