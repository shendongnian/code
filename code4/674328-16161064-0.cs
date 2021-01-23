    public event PropertyChangedEventHandler PropertyChanged;
    private string someMember;
    public int SomeProperty 
    {
        get 
        { return this.someMember; }
        set 
        {
           if (this.someMember != value)
           {
               someMember = value;
               if (PropertyChanged != null)
               {
                   PropertyChanged(this, new PropertyChangedEventArgs("SomeProperty"));
               }
         }
    }
