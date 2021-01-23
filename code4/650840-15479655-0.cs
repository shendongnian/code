    class AUT
    {
       public Guid ID { get; set; }
       public string Name { get; set; }
 
      public Engineer Engineer { get; set; }
    }
    class InstallationSetup
    {
        public virtual AUT ApplicationUnderTesting { get; set; }
        public int ApplicationUnderTestingId {get; set;}   <--- Add this.
 
       public Guid ID { get; set; }
    // Loads of properties etc
    }
    class Engineer
    {
     public Guid ID { get; set; }
     public string Name { get; set; }
    }
