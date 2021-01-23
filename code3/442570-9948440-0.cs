        public void d()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke( new MethodInvoker( delegate() { 
                    foo(a, b); 
                } ) );
            }
            else
            {
                foo(a, b);
            }
        }
        private void foo(int a, int b)
        {
        }
