    using System.Windows.Forms;
    namespace WindowsFormsApplication5 {
        class TextBoxExt : TextBox {
            new public void AppendText(string text) {
                if (this.Text.Length == this.MaxLength) {
                    return;
                } else if (this.Text.Length + text.Length > this.MaxLength) {
                    base.AppendText(text.Substring(0, (this.MaxLength - this.Text.Length)));
                } else {
                    base.AppendText(text);
                }
            }
            public override string Text {
                get {
                    return base.Text;
                }
                set {
                    if (value.Length > this.MaxLength) {
                        base.Text = value.Substring(0, this.MaxLength);
                    } else {
                        base.Text = value;
                    }
                }
            }
        }
