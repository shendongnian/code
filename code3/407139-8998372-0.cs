        public bool Equals(SampleObject x, SampleObject y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;
            return x.Id.Equals(y.Id);
        }
        public int GetHashCode(SampleObject obj)
        {
                   public int GetHashCode(SampleObject obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;
            int hashId = obj.Id == null ? 0 : obj.Id.GetHashCode();
            int hashName = obj.Name == null ? 0 : obj.Name.GetHashCode();
            return hashId ^ hashName; // or what ever you want you hash to be, hashID would work just as well.
        }
        }
