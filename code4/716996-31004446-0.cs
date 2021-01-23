        private ContainerControl _containerControl;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ContainerControl ContainerControl
        {
            get { return _containerControl; }
            set
            {
                _containerControl = value;
                if (DesignMode || _containerControl == null)
                    return;
                if (_containerControl is Form)
                    ((Form) _containerControl).Load += (sender, args) => { Load(); };
                else if (_containerControl is UserControl)
                    ((UserControl)_containerControl).Load += (sender, args) => { Load(); };
                else
                    System.Diagnostics.Debug.WriteLine("Unknown container type. Cannot setup initialization.");
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public override ISite Site
        {
            get { return base.Site; }
            set
            {
                base.Site = value;
                if (value == null)
                    return;
                IDesignerHost host = value.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (host == null)
                    return;
                IComponent componentHost = host.RootComponent;
                if (componentHost is ContainerControl)
                    ContainerControl = componentHost as ContainerControl;
            }
        }
        private void Load()
        {
        }
