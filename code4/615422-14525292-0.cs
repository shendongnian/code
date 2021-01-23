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
            base.OnKeyDown(e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
           // this was checked OnKeyDown this prevents deleteing and writng back behaviour
           if (Text == Prefix && e.KeyChar == '\b') 
                e.Handled = true;
            // Never allow cursor position before Prefix
            if (SelectionStart < _prefix.Length)
                SelectionStart = _prefix.Length;
            base.OnKeyPress(e);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            // Yet, some how if an invalid text is entered fix it by displaying only Prefix
            if (!Text.StartsWith(Prefix))
                Text = Prefix;
            base.OnKeyUp(e);
        }
    }
