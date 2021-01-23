        public void ThreadProc()
        {
            for (int i = 0; i < 100000; i++)
            {
                string proxyName = DoSomeWork();
                this.Invoke(new MethodInvoker(
                    delegate()
                    {
                        labelControl1.Text = proxyName;
                    }
                    ));
                Thread.Sleep(0);
            }
        }
