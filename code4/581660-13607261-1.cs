    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    class MyControl : Control {
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        private new event MouseEventHandler MouseDown;
    }
