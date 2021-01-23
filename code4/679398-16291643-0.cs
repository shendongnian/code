        public bool Contains(Name x)
        {
            if (x == null)
                return false;
            return this.Names.Any(item => item.FirstName == x.FirstName && item.LastName == x.LastName);
        }
