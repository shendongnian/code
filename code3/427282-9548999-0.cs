    using System;
    using System.Drawing;
    using System.Windows.Forms;
    class MyTextBox : TextBox {
        protected override void OnEnter(EventArgs e) {
            prevColor = this.BackColor;
            this.BackColor = Color.Cornsilk;
            base.OnEnter(e);
        }
        protected override void OnLeave(EventArgs e) {
            this.BackColor = prevColor;
            base.OnLeave(e);
        }
        private Color prevColor;
    }
