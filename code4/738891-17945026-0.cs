        public class Account
        {
          public string Email { get; set; }
          public bool Active { get; set; }
          public DateTime CreatedDate { get; set; }
          public IList<string> Roles { get; set; } 
        }
    
    Account account = new Account
      {
        Email = "james@example.com",
        Active = true,
        CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
        Roles = new List<string>
          {
            "User",
            "Admin"
          }
      };
    
    string json = JsonConvert.SerializeObject(account, Formatting.Indented);
    
    Console.WriteLine(json);
