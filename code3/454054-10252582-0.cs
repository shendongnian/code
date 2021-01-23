    using System;
    using System.Windows.Forms;
    
    class MyMaskTextBox : MaskedTextBox {
        protected override void OnKeyDown(KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                e.Handled = e.SuppressKeyPress = true;
                this.Parent.GetNextControl(this, true).Select();
                return;
            }
            base.OnKeyDown(e);
        }
    }
