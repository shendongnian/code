    [Table("Tenant")]
    public class Tenant : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Key]
        public string Guid { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
    
    [Table("User")]
    public class User : IEntity
    {
        public int Id { get; set; }
    
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
    [Test]
    public void CreateNewUserForNewTenant()
    {
        var user = _applicationContext.Users.Create();
        user.Name = "barney"; 
        user.EmailAddress = "barney@flinstone.com";
        var tenant = _applicationContext.Tenents.Create();
        tenant.Name = "localhost";
        tenant.Guid = Guid.NewGuid().ToString();
        tenant.Users = new List<User> { user };
        _tenantRepository.Add(tenant);
        _applicationContext.SaveChanges();
    }
