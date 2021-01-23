    public abstract class AbstractEntity<idType>
        where idType : IEquatable<idType>
    {
        public idType Id { get; set; }
    }
