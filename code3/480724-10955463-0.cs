    IEntity {
        Guid Id { get; set; } 
    }
    interface IAuditable<T> {
        DateTime CreatedAt {get; set; }
        // ...
    }
    class AuditableEntity<T> : IEntity, IAuditable<T> {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
        public AuditableEntity {
             Id = Guid.NewGuid();
        }
    }
    class AuditableValueObject<T> : IAuditable<T> {
        DateTime CreatedAt { get; set; }
    }
    class User : AuditableEntity<User> {
        // ..
    }
    class Money : AuditableValueObject<Money> {
        // ..
    }
