    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ClientSettings
    {
        [Key, ForeignKey("Client"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SettingsId { get; set; }
        public bool SomeSetting { get; set; }
        public virtual Client Client { get; set; }
    }
    class MyContext : DbContext
    {
        public MyContext()
            : base()
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientSettings> ClientSettings { get; set; }
    }
