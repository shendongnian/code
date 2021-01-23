    using System;
    using System.Windows.Forms;
    
    class MyButton : PictureBox {
        public MyButton() {
            this.SetStyle(ControlStyles.StandardDoubleClick, false);
        }
    }
