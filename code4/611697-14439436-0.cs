    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        protected bool Equals(Group other)
        {
            return GroupId == other.GroupId;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Group) obj);
        }
        public override int GetHashCode()
        {
            return GroupId;
        }
    }
