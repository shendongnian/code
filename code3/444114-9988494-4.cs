    var yourObject =  JsonConvert.DeserializeObject<Root>(jsonstring);
    public class Root
    {
        public Profile[] Profile;
    }
    public class Profile
    {
        public string Name { get; set; }
        public string Last { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; }
    }
    public class Client
    {
        public int ClientId;
        public string Product;
        public string Message;
    }
