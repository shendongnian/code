    public class RandomInt : IEnumerable<int>
    {
        int seed;
	
        public RandomInt ()
        {
            seed = new Random ().Next();
        }
	
        public IEnumerator<int> GetEnumerator ()
        {
            return new InternalEnumerator (seed);
        }
		
        protected class InternalEnumerator : IEnumerator<int>
        {
            Random randomGen;
            int current;
            int seed;
			
            protected InternalEnumerator (int seed)
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
            public int Current {
                get {
                    if (randomGen == null)
                        throw new InvalidOperationException ("Enumerator in reset state");
                    return current;
                }
            }
            #endregion
        }
    }
