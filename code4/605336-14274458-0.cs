    public class TestContext : DbContext
    {
       public TestContext()
       {
          Configuration.AutoDetectChangesEnabled = true;
          Configuration.LazyLoadingEnabled = true;
          Configuration.ProxyCreationEnabled = true;
          Configuration.ValidateOnSaveEnabled = true;
       }
       public virtual DbSet<NetowkDevice> NetowkDevices{ get; set; }
       public virtual DbSet<ControllerDevice> ControllerDevices{ get; set; }
       public virtual DbSet<Controller> Controlleres{ get; set; }
    }
