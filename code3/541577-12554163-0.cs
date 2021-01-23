    class ChatBox : TextBox {
        public ChatBox() {
            this.Multiline = true;
        }
        protected override bool IsInputKey(Keys keyData) {
            if (keyData == (Keys.Shift | Keys.Enter)) return true;
            return base.IsInputKey(keyData);
        }
        protected override void OnKeyDown(KeyEventArgs e) {
            if (e.KeyData == (Keys.Shift | Keys.Enter)) {
                int pos = this.SelectionStart;
                this.SelectedText = Environment.NewLine;
                this.SelectionStart = pos;
                e.Handled = e.SuppressKeyPress = true;
                return;
            }
            base.OnKeyDown(e);
        }
    }
