    change(ref p);
    //p is now passed by reference so p1 is p
    public void change(ref Person p1)//p1 and p are same
    {
        p1.Name="SO";
        p1=null;//this makes p and p1 null
    }
