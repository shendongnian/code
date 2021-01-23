    [TestFixture]
    public class ListTest
    {
        [Test]
        public void UpdateTest()
        {
            var user = new User();
            user.Addresses.Add(new Address{Name = "Johan"});
            user.Addresses[0] = new Address { Name = "w00" };
        }
    }
    public class User
    {
        public List<Address> Addresses { get;private  set; }
    
        public User()
        {
            Addresses= new List<Address>();
        }
    }
    public class Address
    {
        public string Name { get; set; }
    }
