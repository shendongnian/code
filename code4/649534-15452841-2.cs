        protected bool Equals(DateRange other)
        {
            return Start.Equals(other.Start) && End.Equals(other.End);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (Start.GetHashCode()*397) ^ End.GetHashCode();
            }
        }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public IEnumerable<DateTime> GetDiscreetDates()
        {
            //Start is not allowed to equal end.
            if (Start.Date == End.Date)
                throw new ArgumentException("Start cannot equal end.");
            var output = new List<DateTime>();
            var current = Start.Date;
            while (current < End.Date) {
                output.Add(current);
                current = current.AddDays(1);
            }
            return output;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DateRange) obj);
        }
    }
