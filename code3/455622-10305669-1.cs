    public class Node
    {
        protected Node Next { get; private set; }
        private Delegate m_actionDel;
        private object[] m_args;
        public Node(Node next, Delegate actionToPerform)
        {
            Next = next;
            m_actionDel = actionToPerform;
        }        
        public void InvokeChain()
        {
            try
            {
                m_actionDel.DynamicInvoke(m_args);
            }
            catch(Exception e)
            {
                // handle exception
            }
            if (Next != null)
                Next.InvokeChain();
        }
    }
