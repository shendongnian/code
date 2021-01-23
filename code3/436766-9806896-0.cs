            ThreadPool.QueueUserWorkItem((x) =>
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
                }
            });
