        public void Attach(City entity)
        {
            if (entity != null)
            {
                Attach(entity.Country);
                AttachAndMarkAs(entity, entity.EntityState ?? EntityState.Added, instance => instance.Id);
            }
        }
        public void Attach(Country entity)
        {
            if (entity != null)
            {
                AttachAndMarkAs(entity, entity.EntityState ?? EntityState.Added, instance => instance.Id);
            }
        }
