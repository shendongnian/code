    public class A : IEnumerable
    {
        public B Next { get; set; }
    
        public String Value { get; set; }
    
        public A(string value, B next)
        {
            this.Next = next;
            this.Value = value;
        }
    
        #region IEnumerable Members
    
        private class AEnumerator : IEnumerator
        {
            private readonly A head;
    
            public AEnumerator(A head)
            {
                this.head = head;
            }
    
            #region IEnumerator Members
    
            public object Current { get; private set; }
    
            public bool MoveNext()
            {
                if (Current == null)
                {
                    Current = head;
                }
                else
                {
                    if (Current.GetType() == typeof(A))
                    {
                        Current = ((A)Current).Next;
                    }
                    else
                    {
                        Current = ((B)Current).Next;
                    }
                }
    
                return Current != null;
            }
    
            public void Reset()
            {
                throw new NotImplementedException();
            }
    
            #endregion
        }
    
        public IEnumerator GetEnumerator()
        {
            return new AEnumerator(this);
        }
    
        #endregion
    }
