    public class EntityObComparer : IEqualityComparer<EntityObject>
    {
        public bool Equals(EntityObject x, EntityObject y)
        {
            return x.EntityKey.Equals(y.EntityKey);
        }
        public int GetHashCode(EntityObject obj)
        {
            return obj.GetHashCode();
        }
    }
