    public class Modelo<T>
    {
        public virtual int Id { get; protected set; }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            Modelo<T> specificOject = (Modelo<T>)obj;
            return (this == obj || this.Id == specificOject.Id);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ 5;
        }
    }
