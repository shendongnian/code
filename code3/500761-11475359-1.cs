    using System;
    using System.Collections;
    class A : IEnumerable
	{
		int[] data = { 0, 1, 2, 3, 4 };
        public IEnumerator GetEnumerator()
        {
            return new AEnumerator(this);
        }
		private class AEnumerator : IEnumerator
		{
            public AEnumerator(A inst)
            {
                this.instance = inst;
            }
		    private A instance;
            private int position = -1;
            public object Current
            {
                get
                {
                    return instance.data[position];
                }
            }
            public bool MoveNext()
            {
                position++;
                return (position < instance.data.Length);
            }
            public void Reset()
            {
                position = -1;
            }
		    
		}
	}
