    public class EquiptmentRepository
    {
        public void Add(Manufacturer m)
        {
            // perform some local logic before calling IDbSet.Add
            this.AddToDbSet(m);
        }
    
        protected virtual AddToDbSet(Manufacturer m)
        {
            this.context.Manfuacturers.Add(m);
        }
    }
