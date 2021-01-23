    //code goes in your Component/Control
    
     private ContainerControl _containerControl = null;
     //Will contain a reference to the Form hosting this Component
            public ContainerControl ContainerControl
            {
                get { return _containerControl; }
                set { _containerControl = value; 
                     //In here setup what you need from the Form
                     //for example add a handler
                    }
            }
    
            //Allows the VS.NET designer to set the ContainerControl
            //in the designer code. Stolen from ErrorProvider.
            public override ISite Site
            {
                set
                {
                    base.Site = value;
                    if (value != null)
                    {
                        IDesignerHost host = value.GetService(typeof(IDesignerHost)) as IDesignerHost;
                        if (host != null)
                        {
                            IComponent rootComponent = host.RootComponent;
                            if (rootComponent is ContainerControl)
                            {
                                this.ContainerControl = (ContainerControl)rootComponent;
                            }
                        }
                    }
                }
            }
