    class Country
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public Country( int i,string s) { Name = s; ID = i; }
    }
    class ComboItem
    {
        public string DisplayMember { get; set; }
        
        public int ValueMember { get; set; }
    }
    class ComboItemEqualityComparer : IEqualityComparer<ComboItem>
    {
        public bool Equals(ComboItem item1, ComboItem item2)
        {
            if (item1.ValueMember == item2.ValueMember && item1.DisplayMember == item2.DisplayMember)
            {
                return true;
            }
            return false;
        }
        public int GetHashCode(ComboItem item)
        {
            string str = item.DisplayMember + item.ValueMember;
            return str.GetHashCode();
        }
    }
