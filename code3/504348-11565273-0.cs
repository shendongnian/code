    class Foo
    {
        private Control m_invoker;
        public Foo()
            : this(null)
        {
        }
        public Foo(Control invoker)
        {
            if (invoker == null)
            {
                // assume we are created on the UI thread, 
                // if not bad things will ensue
                m_invoker = new Control();
            }
            else
            {
                m_invoker = invoker;
            }
        }
        public void Bar()
        {
            m_invoker.Invoke(new Action(delegate
            {
                // do my UI-context stuff here
            }));
        }
    }
