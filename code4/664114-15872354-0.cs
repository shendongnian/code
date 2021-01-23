    public struct Devided
    {
        public int Reminder { get; set; }
        public List<int> Numbers { get; set; }
        public override bool Equals(object obj)
        {
            if(!(obj is Devided))
                return false;
            var d = (Devided)obj ;
            if(object.ReferenceEquals(this, d))
                return true;
            return this.Reminder == d.Reminder && this.Numbers.SequenceEqual(d.Numbers);
        }
        public override int GetHashCode()
        {
            return Reminder;
        }
    }
