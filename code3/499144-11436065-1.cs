    public class RandomInt : IEnumerable
    {
        int seed;
	
        public RandomInt ()
        {
            seed = new Random ().Next();
        }
	
        public IEnumerator GetEnumerator ()
        {
            return new InternalEnumerator (seed);
        }
		
        protected class InternalEnumerator : IEnumerator 
        {
            Random randomGen;
            int current;
            int seed;
			
            internal InternalEnumerator (int seed)
            {
                this.seed = seed;
            }
			
            #region IEnumerator implementation
            public bool MoveNext ()
            {
                if (randomGen == null)
                    randomGen = new Random (seed);
                current = randomGen.Next();
                return true;
            }
            public void Reset ()
            {
                randomGen = null;
            }
            public object Current {
                get {
                    if (randomGen == null)
                        throw new InvalidOperationException ("Enumerator in reset state");
                    return current;
                }
            }
            #endregion
        }
    }
