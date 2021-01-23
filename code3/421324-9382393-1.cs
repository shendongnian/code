    .OrderBy(m => m)
---
    class Type_of_m : IComparable<Type_of_m>
    {
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public int CompareTo(Type_of_m other)
        {
            int comp = Name.CompareTo(other.Name);
            if (comp != 0) {
                return comp;
            }
            return CreationTime.CompareTo(other.CreationTime);
        }
    }
