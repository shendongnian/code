    private string firstName;
    public string FirstName
    {
         get { return this.firstName; }
         set
         {
             if(this.firstName != value)
             {
                this.firstName = value; // Set field
                OnPropertyChanged("FirstName");
             }
         }
    }
