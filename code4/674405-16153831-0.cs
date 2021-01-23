    Foo c = new Foo( cBAdmin );
    c.DoSomethingWithComboBox();
    
    public class Foo
        {
            private ComboBox m_cb;
            public Foo(ComboBox cb)
            {
                m_cb = cb;
            }
            public void DoSomethingWithComboBox()
            {
                //Do something with m_cb
            }
        }
    }
