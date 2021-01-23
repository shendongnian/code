    public class ContactComparer : EqualityComparer<Contact>
    {
        public override bool Equals(Contact x, Contact y)
        {
            if (ReferenceEquals(x, y)) return true;
            return x != null && y != null && x.ContactId == y.ContactId;
        }
        public override int GetHashCode(Contact obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            // assuming string
            return (obj.ContactId ?? "").GetHashCode();
        }
    }
