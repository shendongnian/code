    class Email:IComparable<Email>
    {
        private static int _Id;
        public Email()
        {
            Id = _Id++;
        }
        public int Id { get; private set; }
        public string UserName { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public DateTime TimeStamp { get; set; }
        public override int GetHashCode()
        {
            return UserName.GetHashCode() ^ Body.GetHashCode() ^ Subject.GetHashCode();
        }
        public int CompareTo(Email other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }
        public override string ToString()
        {
            return String.Format("ID:{0} - {1}", Id, Subject);
        }
        public override bool Equals(object obj)
        {
            if (obj is Email)
                return CompareTo(obj as Email) == 0;
            return false;
        }
    }
