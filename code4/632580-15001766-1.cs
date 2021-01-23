    class Namespace1MyTypeAdapter : IMyType
    {
        private readonly Namespace1.MyType m_adapted;
    
        public Namespace1MyTypeAdapter(Namespace1.MyType adapted)
        {
            m_adapted = adapted;
        }
    
        public object InnerType
        {
            get { return m_adapted.InnerType; }
            set { m_adapted.InnerType = value; }
        }
    
        public void PerformMethod1()
        {
            m_adapted.PerformMethod1();
        }
    }
