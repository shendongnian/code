    public partial class Form1 : Form
    {
        private bool nonNumberEntered = false;
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyDown+=new KeyEventHandler(textBox1_KeyDown);
            textBox1.KeyPress+=new KeyPressEventHandler(textBox1_KeyPress);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
        }
    }
