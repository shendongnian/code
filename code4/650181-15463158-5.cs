        public override int GetHashCode()
        {
            var hashcode = Id.GetHashCode();
            hashCode ^= Name.GetHashCode();
            return hashCode;
        }
