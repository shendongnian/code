    public Table<FormsAuthorisation> GetFormsAuthorisation()
    {
        MyDataClassesDataContext dc = new MyDataClassesDataContext();
        return GetFormsAuthorisation(dc);
    }
    
    public Table<FormsAuthorisation> GetFormsAuthorisation(MyDataClassesDataContext dc)
    {
        //do whatever you already do inside your GetFormsAuthorisation function using dc parameter
    }
