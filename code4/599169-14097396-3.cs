    public class Contact : IPerson, ILocation
    {
      public Contact()
      {
        // Initialize the emails list
        this.Emails = new List<Emails>();
      }
    
      [MaxLength(256)]
      public string EmailAddress
      { 
        get
        {
          // You'll need to decide what to return if the first email has not been set.
          // Replace string.Empty with the appropriate value.
          return this.Emails.Count == 0 ? string.Empty : this.Emails[0].ToString();
        } 
        set
        {
          if (this.Emails.Count == 0)
          {
            this.Emails.Add(new Emails());
          }
          this.Emails[0].EmailAddress = value;
    	}
      }
      
      public virtual IList<Emails> Emails { get; set; }
    }
