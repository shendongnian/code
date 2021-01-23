    public partial class UserControl1 : UserControl
    {
        string mask;
        public UserControl1()
        {
            InitializeComponent();
            textBox1.MaxLength = 7;
            textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
           
        }
        void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !( e.KeyChar == 0x8) && !(e.KeyChar == 0xd))
                e.Handled = true;
        }
        void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.TextLength == 0)
            {
                tb.Text = mask;
                tb.SelectionStart = tb.Text.Length;
            }
            else
            {
                if (tb.Text[0] != mask[0])
                {
                    tb.Text = mask[0] + tb.Text;
                    tb.SelectionStart = tb.Text.Length;
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mask = ((ComboBox)sender).SelectedItem.ToString();
            textBox1.Text = mask;
        }
    }
