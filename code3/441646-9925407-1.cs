    class Program
    {
        static void Main(string[] args)
        {
            var userList = new List<Users>();
            Enumerable.Range(0, 100).ToList().ForEach(x => userList.Add(new Users() { ID = x, Name = "Bob" }));
            int count = userList.Count(u => u.ID == 1 && u.Name == "Bob");
            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
    public class Users
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
