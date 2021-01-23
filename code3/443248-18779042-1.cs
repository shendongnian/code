    namespace WindowsFormsApplication10
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            double no;
            no = double.Parse(textBox1.Text);
            string[] ones = new string[19] {"one ","two ","three ","four ","five ","six ","seven ","eight ","nine ","ten ","eleven ","twele ",
                                            "thiten ","fourten ","fiften ","sixten ","seventeen ","eighteen ", "ninteen "};
            string[] tens = new string[9] { "ten ", "twenty ", "thirty ", "fourty ", "fifty ", "sixty ", "seventy ", "eighty ", "ninty " };
            int i=0;
            if (no > 999 & no < 100000)
            {
                i = (int)no / 1000;
                if (i < 20)
                    label1.Text = label1.Text + ones[i - 1] + "";
                else if (i > 20)
                {
                    int r = 0;
                    r = i % 10;
                    i = i / 10;
                    label1.Text = label1.Text + tens[i - 1] + "";
                    label1.Text = label1.Text + ones[r - 1] + "";
                }
                label1.Text = label1.Text + "thousand ";
                no = no % 1000;
            }
            if (no > 99 & no < 1000)
            {
                i = (int)no / 100;
                label1.Text = label1.Text + ones[i - 1] + "hundred ";
                no = no % 100;
            }
            if (no > 19 & no < 99)
            {
                i = (int)no / 10;
                label1.Text = label1.Text + tens[i - 1];
                no = no % 10;
            }
            if (no > 0 & no < 20)
            {
                label1.Text = label1.Text + ones[(int)no-1] + " ";
            }
            label1.Text = label1.Text + "Rupees ";
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "";
            textBox1.Focus();
        }
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
         && !char.IsDigit(e.KeyChar)
         && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            // only allow one decimal point 
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            string word = textBox1.Text.Trim();
            string[] wordArr = word.Split('.');
            if (wordArr.Length > 1)
            {
                string afterDot = wordArr[1];
                if (afterDot.Length > 1)
                {
                    e.Handled = true;
                }
            }
            
        }
    }
    }
