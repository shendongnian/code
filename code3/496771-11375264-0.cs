    using System;
    using System.Windows.Forms;
    
    class BufferedPanel : Panel {
        public BufferedPanel() {
            this.DoubleBuffered = true;
        }
    }
