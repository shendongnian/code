        public void Method(string s)
        {
            label1.Text = string.Format("{0} '{1}'", 
                            Thread.CurrentThread.ManagedThreadId, s);
        }
