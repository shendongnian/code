    public class ClassB
    {
        private ClassC m_C = new ClassC();
       
        public event EventHandler MyEvent
        {
            add { m_C.MyEvent += value; }
            remove { m_C.MyEvent -= value; }
        }
    }
