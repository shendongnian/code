    public class YourClassName
    {
        private List<Type> m_InnerList = new List<Type>();
        public event EventHandler OnBatch;
        public void Add(Type object)
        {
            m_InnerList.Add(object);
            if ((m_InnerList.Count % YourCountHere == 0) && OnBatch != null)
               OnBatch(this, new EventArgs());
       
        }
