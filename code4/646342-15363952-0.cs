      namespace BLL.Presenters
      {
        using System;
        public class Account // dummy to make it compile
        {
          public string Email;
          public bool Active;
          public string FirstName;
          public string LastName;
          public bool Administrator;
          public DateTime? LastLogin;
          public Guid ID;
          public DateTime Created;
          public DateTime Modified;
        }
        public class AccountsView
        {
          public string Email { get; set; }
          public bool Active { get; set; }
          public string FirstName { get; set; }
          public string LastName { get; set; }
          public AccountsView(Account data)
          {
            this.Email = data.Email;
            this.Active = data.Active;
            this.FirstName = data.FirstName;
            this.LastName = data.LastName;
          }
        }
        public class Details : AccountsView
        {
          public bool Administrator { get; set; }
          public DateTime? LastLogin { get; set; }
          public Details(Account data) : base(data)
          {
            this.Administrator = data.Administrator;
            this.LastLogin = data.LastLogin;
          }
        }
        public class Full : Details
        {
          public Guid ID { get; set; }
          public DateTime Created { get; set; }
          public DateTime Modified { get; set; }
          public string FullName { get; set; }
          public Full(Account data) : base(data)
          {
            this.ID = data.ID;
            this.Created = data.Created;
            this.Modified = data.Modified;
            this.FullName = data.LastName + ", " + data.FirstName;
          }
        }
      
        class Program
        {
          static void Main()
          {
            Console.WriteLine();
            Console.ReadLine();
          }
        }
      }
