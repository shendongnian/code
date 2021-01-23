    class Test : Form
    {
            delegate void FooCallback(string status);
    
    
            public Test()
            {
            }
    
            private void foo(string status)
            {
                if (this.InvokeRequired == true)
                {
                    FooCallback = new FooCallback(foo);
                    this.Invoke
                        (d, status);
    
                }
                else
                {
                  //Do Things
    
                }
            }     
    }
