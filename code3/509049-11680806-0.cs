    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    class MyComponent : Component {
    
        public bool ShowDialog() {
            using (var dlg = new WindowsFormsApplication1.Form2()) {
                if (dlg.ShowDialog() == DialogResult.OK) {
                    // Retrieve properties
                    //...
                    return true;
                }
                else return false;
            }
        }
        // Add your own properties here
        //...
    
    }
