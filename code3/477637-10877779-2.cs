    public class Account
    {
          public string Code { get; set; }
          public string Description { get; set; }
          public DateTime CreatedOn { get; private set; }  
          public Account()
          {
              Description = string.Empty;
              CreatedOn = DateTime.Now;
              //Code = ...
          }
          public Account(string Description)
          {
              this.Description = Description;
              CreatedOn = DateTime.Now;
              //Code = ...
          }
    }
