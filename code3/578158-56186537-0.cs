    {
      public Customer()
      {
        Orders = new Collection<Order>();
      }
 
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
 
    [JsonIgnore]
    public ICollection<Order> Orders { get; set; }
    }
