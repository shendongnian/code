    public class CChainList<T> : IEnumerable where T : CEntity
    {
        public CChainElement<T> m_First;
    
        internal void Add(T Element)
        {
            CChainElement<T> newNode = new CChainElement<T>() { Value = Element };
            if (m_First != null)
               m_first.m_prev = newNode;
    
            m_First = newNode;
        }
    }
