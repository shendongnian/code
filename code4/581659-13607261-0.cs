    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    class MyControl : Control {
        [Browsable(false)]
        public new event MouseEventHandler MouseDown;
    }
