    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public static User Parse(string s)
        {
            var parts = s.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            return new User {
                Id = Int32.Parse(parts[0]),
                Name = parts[1],
                Location = parts[2]
            };
        }
        public override string ToString()
        {
            return String.Format("{0:00000} {1} {2}", Id, Name, Location);
        }
    }
