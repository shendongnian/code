    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Windows.Forms;
    
    public class DeviceChangeNotifier : Component {
        public delegate void DeviceChangeDelegate(Message msg);
        public event DeviceChangeDelegate DeviceChange;
    
        public DeviceChangeNotifier() {
            // Add initialization here
        }
        public DeviceChangeNotifier(IContainer container) : this() {
            // In case you need automatic disposal
            container.Add(this);
        }
        public DeviceChangeNotifier(ContainerControl parentControl) : this() {
            // In case you want to use it without the designer            
            this.ContainerControl = parentControl;
        }
    
        public ContainerControl ContainerControl {
            // References the parent form
            get { return this.parentControl; }
            set { 
                this.parentControl = value;
                this.parentControl.HandleCreated += parentControl_HandleCreated;
            }
        }
    
        private void parentControl_HandleCreated(object sender, EventArgs e) {
            // Subclass the form when its handle is created
            snooper = new MessageSnooper(this, parentControl.Handle);        
        }
    
        protected void OnDeviceChange(Message msg) {
            // Raise the DeviceChange message
            var handler = DeviceChange;
            if (handler != null) handler(msg);
        }
    
        public override ISite Site {
            // Runs at design time, ensures designer initializes ContainerControl 
            // so we'll have a reference to the parent form without it having to do any work
            set { 
                base.Site = value;
                if (value == null) return;
                IDesignerHost service = value.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (service == null) return;
                IComponent rootComponent = service.RootComponent;
                this.ContainerControl = rootComponent as ContainerControl;
            }
        }
    
        private ContainerControl parentControl;
        private MessageSnooper snooper;
        private const int WM_DESTROY = 0x0002;
        private const int WM_DEVICECHANGE = 0x0219;
    
        private class MessageSnooper : NativeWindow {
            // Subclasses the parent window
            public MessageSnooper(DeviceChangeNotifier owner, IntPtr handle) {
                this.owner = owner;
                this.AssignHandle(handle);
            }
            protected override void WndProc(ref Message m) {
                if (m.Msg == WM_DESTROY) this.ReleaseHandle();
                if (m.Msg == WM_DEVICECHANGE) owner.OnDeviceChange(m);
                base.WndProc(ref m);
            }
            private DeviceChangeNotifier owner;
        }
    }
