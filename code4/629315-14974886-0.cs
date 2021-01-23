    namespace external
    {
        public abstract class Framework
        {
            public abstract Entity RecordType { get; } 
        }
        public sealed class Entity
        {
            int value;
    
            Entity()
            {
    
            }
            
            public static implicit operator Entity(int i)
            {
                return new Entity { value = i };
            }
    
            public bool Equals(Entity other)
            {
                if (ReferenceEquals(this, other))
                    return true;
    
                if (ReferenceEquals(null, other))
                    return false;
    
                return value == other.value;
            }
    
            public override bool Equals(object obj)
            {
                return Equals(obj as Entity);
            }
    
            public static bool operator ==(Entity lhs, Entity rhs)
            {
                if (ReferenceEquals(lhs, null))
                    return ReferenceEquals(rhs, null);
    
                return lhs.Equals(rhs);
            }
    
            public static bool operator !=(Entity lhs, Entity rhs)
            {
                return !(lhs == rhs);
            }
    
            public override int GetHashCode()
            {
                return value;
            }
    
            public override string ToString()
            {
                return value.ToString();
            }
        }
    }
