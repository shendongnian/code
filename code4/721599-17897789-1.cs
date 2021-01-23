    class User : SecuredEntity { }
    abstract class SecuredEntity : Entity, ISecureInfo
    {
        public string Password { get; set; }
    }
    abstract class Entity : IGeneralInfo
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
    interface IGeneralInfo
    {
        string ID { get; set; }
        string Name { get; set; }
    }
    interface ISecureInfo
    {
        string Password { get; set; }
    }
