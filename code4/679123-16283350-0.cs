        public virtual bool IsInstanceOfType(object o)
        {
            if (o == null)
            {
                return false;
            }
            return this.IsAssignableFrom(o.GetType());
        }
