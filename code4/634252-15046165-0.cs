    public class MyEntry
    {
        public ObjectId Id { get; set; }
        public string SimpleHash { get; set; }
        public string GroupIdentifier { get; set; }
    }
    var update = Update<MyEntry>.Combine(
        Update<MyEntry>.Set(m => SimpleHash, "TheHash!"),
        Update<MyEntry>.Set(m => GroupIdentifier, "MyGroup"));
