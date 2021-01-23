    public class Modelo<T>
    {
        // 1) note PROTECTED set on Id
        public virtual int Id { get; protected set; }
        public override bool Equals(object obj)
        {
            ...
            // 2) comparison is based on Id
            return (this == obj || this.Id == specificOject.Id);
        }
        ...
    }
    public class Medicion : Modelo<Medicion> {...}
