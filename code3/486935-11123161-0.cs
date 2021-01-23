    public abstract class TEntity
    {
        public override bool Equals(object entity)
        {
            return entity != null
                && entity is EntityBase
                && this == (EntityBase)entity;
        }
        public static bool operator ==(EntityBase base1, 
            EntityBase base2)
        {
            if ((object)base1 == null && (object)base2 == null)
            {
                return true;
            }
            if ((object)base1 == null || (object)base2 == null)
            {
                return false;
            }
            if (base1.Key != base2.Key)
            {
                return false;
            }
            return true;
        }
        public static bool operator !=(EntityBase base1, 
            EntityBase base2)
        {
            return (!(base1 == base2));
        }
    }
