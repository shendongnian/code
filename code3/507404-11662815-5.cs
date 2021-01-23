    public class Person : IEntityWithKey
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public EntityKey EntityKey { get; set; }
    }
