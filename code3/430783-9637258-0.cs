    public class TextBoxPlus : TextBox {
        public event CancelEventHandler ProgrammerChangedText;
        protected void OnProgrammerChangedText(CancelEventArgs e) {
            CancelEventHandler handler = ProgrammerChangedText;
            if (handler != null) { handler(this, e); }
        }
        public override string Text {
            get {
                return base.Text;
            }
            set {
                string oldtext = base.Text;
                base.Text = value;
                CancelEventArgs e = new CancelEventArgs();
                OnProgrammerChangedText(e);
                if (e.Cancel) base.Text = oldtext;
            }
        }
    }
