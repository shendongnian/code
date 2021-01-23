    class Emails : HashSet<string>
    {
        public Emails(string concatenatedList)
            : base(concatenatedList.Split(','))
        {
        }
        public override string ToString()
        {
            return string.Join(",", this);
        }
    }
