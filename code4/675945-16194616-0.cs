    public class Node : IDisposable
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node(int value)
        {
            this.Value = value;
        }
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Next != null) // <-- new code here
                {
                    Next.Dispose();
                }                 
            }
        }
    }
