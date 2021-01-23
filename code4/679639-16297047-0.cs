    public ZipLoad(string uName,string pWord)
    {
    user1= uName;
    pass1=pWord;
    DOit(uName,pWord);
    }
    private string user1;
    private string pass1;
    public string setUser
    {
        set { user1 = value ; }
    }
    public string setPass
    {
        set { pass1 = value; }
    }
    private void DOit(string uName, string pWord)
    {
      Do some stuff...
    }
