    public class Foo<T> : IEnumerable<T>
    {
        private IEnumerable<T> sequence;
    
        private int? myHashCode = null;
    
        public Foo(IEnumerable<T> sequence)
        {
            this.sequence = sequence;
        }
    
        public IEnumerator<T> GetEnumerator()
        {
            return sequence.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return sequence.GetEnumerator();
        }
    
        public override bool Equals(object obj)
        {
            Foo<T> other = obj as Foo<T>;
            if(other == null)
                return false;
    
            //if the hash codes are different we don't need to bother doing a deep equals check
            //the hash code is cached, so it's fast.
            if (GetHashCode() != obj.GetHashCode())
                return false;
    
            return Enumerable.SequenceEqual(sequence, other.sequence);
        }
    
        public override int GetHashCode()
        {
            //note that the hash code is cached, so the underlying sequence 
            //needs to not change.
            return myHashCode ?? populateHashCode();
        }
    
        private int populateHashCode()
        {
            int somePrimeNumber = 37;
            myHashCode = 1;
            foreach (T item in sequence)
            {
                myHashCode = (myHashCode * somePrimeNumber) + item.GetHashCode();
            }
    
            return myHashCode.Value;
        }
    }
