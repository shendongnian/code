        public int CompareTo(Flow other)
        {
          // Alphabetic sort if name is equal.
          if this.Name == other.Name
          {
            return this.Name.CompareTo(other.Name);
          }
         //Default sort.
         return other.Name.CompareTo(this.Name);
        }
