    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Prefix = @"DOMAIN\";
        }
    }
    class PrefixedTextBox : TextBox
    {
        private string _prefix = String.Empty;
        public string Prefix
        {
            get { return _prefix; }
            set
            {
                _prefix = value;
                Text = value;
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Don't allow Backspace and Delete if the only text is Prefix
            if (Text == Prefix && (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete))
                e.Handled = true;
            // If home key is pressed set cursor just after the prefix
            if (e.KeyCode == Keys.Home)
            {
                e.Handled = true;
                SelectionStart = Prefix.Length;
            }
            // Don't allow cursor to be moved inside Prefix
            if (SelectionStart <= Prefix.Length && (e.KeyCode == Keys.Left || e.KeyCode == Keys.Up))
                e.Handled = true;
            base.OnKeyDown(e);
        }
        protected override void OnClick(EventArgs e)
        {
            EnsureCursorPosition();
            base.OnClick(e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            EnsureCursorPosition();
            // this was checked OnKeyDown. This prevents deleting and writing back behaviour
            if (Text == Prefix && e.KeyChar == '\b')
                e.Handled = true;
            
            base.OnKeyPress(e);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            // Yet, some how an invalid text is entered fix it by just displaying the Prefix
            if (!Text.StartsWith(Prefix))
                Text = Prefix;
            base.OnKeyUp(e);
        }
        private void EnsureCursorPosition()
        {
            // Never allow cursor position before Prefix
            if (SelectionStart < Prefix.Length)
                SelectionStart = Text.Length;
        }
    }
