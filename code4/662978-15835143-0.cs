        if (this.controlname.InvokeRequired && !this.controlname.IsDisposed)
                    {
                        Invoke(new MethodInvoker(delegate()
                            {
                                //Update control on GUI here!
        
        }));
        else if(!this.controlname.IsDisposed)
       {
                               //AND here!
       }
