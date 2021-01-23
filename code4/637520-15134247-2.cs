    struct client
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int age { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is client))
                return false;
            client c = (client)obj;
            return
                (string.Compare(FName, c.FName) == 0) &&
                (string.Compare(LName, c.LName) == 0);
        }
        public override int GetHashCode()
        {
            if (FName == null)
            {
                if (LName == null)
                    return 0;
                else
                    return LName.GetHashCode();
            }
            else if (LName == null)
                return FName.GetHashCode();
            else
                return FName.GetHashCode() ^ LName.GetHashCode();
        }
    }
