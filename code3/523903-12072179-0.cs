    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Windows.Forms;
    
    public partial class Component1 : Component {
        private ContainerControl parent;
        [Browsable(false)]
        public ContainerControl ContainerControl {
            get { return parent; }
            set {
                if (parent == null) {
                    var form = value.FindForm();
                    if (form != null) form.Load += new EventHandler(form_Load);
                }
                parent = value;
            }
        }
        public override ISite Site {
            set {
                // Runs at design time, ensures designer initializes ContainerControl
                base.Site = value;
                if (value == null) return;
                IDesignerHost service = value.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (service == null) return;
                IComponent rootComponent = service.RootComponent;
                this.ContainerControl = rootComponent as ContainerControl;
            }
        }
    
        void form_Load(object sender, EventArgs e) {
            if (!this.DesignMode) {
                MessageBox.Show("Trial");
            }
        }
    }
