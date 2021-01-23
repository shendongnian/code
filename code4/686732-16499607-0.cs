    public class User {
      public string Id { get; set; }
      public string Name { get; set; }
      public string Surname { get; set; }
      public string Telephone { get; set; }
      public bool Vip { get; set; }
      public int Age { get; set; }
      public decimal Balance { get; set; }
      public static List<User> LoadUserListFromFile(string path) {
        var users = new List<User>();
        foreach (var line in File.ReadAllLines(path)) {
          var columns = line.Split('\t');
          users.Add(new User {
            Id = columns[0],
            Name = columns[1],
            Surname = columns[2],
            Telephone = columns[3],
            Vip = columns[4] == "1",
            Age = Convert.ToInt32(columns[5]),
            Balance = Convert.ToDecimal(columns[6])
          });
        }
        return users;
      }
    }
