    public class CChainElement
    {
        public CChainElement m_Prev, m_Next;
    }
    
    public class CChainList<T> : IEnumerable
       where T : CChainElement
    {
        public T m_First;
    
        internal void Add(T Element)
        {
            if (m_First != null)
                m_First.m_Prev = Element;
    
            Element.m_Next = m_First;
            m_First = Element;
        }
    }
    
    public class CEntity : CChainElement
    {
    }
    
    public class CItem : CEntity
    {
    }
    
    public class CTest
    {
        void Test()
        {
            CChainList<CItem> AllItem = new CChainList<CItem>();
            CItem Item = new CItem();
    
            AllItem.Add(Item);
    
            CItem FirstItem = AllItem.m_First;
            CItem SecondItem = FirstItem.m_Next;
        }
    }
