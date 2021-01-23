    public class MyCustomList : ICollection
    {
        private readonly ArrayList m_InnerList = new ArrayList();
        
        public virtual void Add(Class1 item) {
            this.m_InnerList.Add(item);
        }
        public virtual void Add(Class2 item) {
            this.m_InnerList.Add(item);        
        }
        
        
        public void CopyTo(Array array, int index) { 
            m_InnerList.CopyTo(array, index);
        }
        public int Count { get { return m_InnerList.Count; } }
        public bool IsSynchronized { get{ return m_InnerList.IsSynchronized; } }
        public object SyncRoot { get{ return m_InnerList.SyncRoot; } }
        public IEnumerator GetEnumerator(){
            return m_InnerList.GetEnumerator();
        }
    } 
