    public interface IEntity<T>:IEntity {
        new T Id { get; set; }
    }
     public interface IEntity {
        object Id { get; }
    }
