        public override bool Equals(object obj)
        {
            if (!(obj is Tuple<T1, T2>))
                return false;
            var t = (Tuple<T1, T2>)obj
            return (this.Item1 == t.Item1 && this.Item2 == t.Item2);
        }
        public override int GetHashCode()
        {
            return (Item1 ^ Item2 );
        }
