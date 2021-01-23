    class Entity {
        Guid Id { get; set; } 
        public Entity() {
            Id = Guid.NewGuid();
        }
    }
    interface IAuditable<T> {
        DateTime CreatedAt {get; set; }
        // ...
    }
    class AuditableEntity<T> : Entity, IAuditable<T> {
        DateTime CreatedAt { get; set; }
    }
    class AuditableValueObject<T> : IAuditable<T> {
        DateTime CreatedAt { get; set; }
    }
    // Class that has both an identity and is auditable
    class User : AuditableEntity<User> {
        // ..
    }
    // Class without an identity but auditable
    class Money : AuditableValueObject<Money> {
        // ..
    }
   
    // Class with an identity but not auditable
    class Customer : Entity {
        // ..
    }
