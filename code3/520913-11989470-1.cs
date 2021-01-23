    public static MyClass Values()
    {
        MyClass myClass = new MyClass();
        MyClass.Length = DAL.Util.getlength();
        MyClass.Name = DAL.Util.getName(ddlID.SelectedValue);
        return MyClass;
    }
