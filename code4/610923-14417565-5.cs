    public partial class Form1 : Form
        {
            public decimal myDecimal = 0;
    
            public Form1()
            {
                InitializeComponent();
                // init value
                tbxConvertito.Text = myDecimal.ToString();
                numericUpDown1_ValueChanged(this, EventArgs.Empty);
            }
    
            private void numericUpDown1_ValueChanged(object sender, EventArgs e)
            {
                int decimalPlace = (int)numericUpDown1.Value;
    
                string[] numbers = myDecimal.ToString().Split(new char[] { '.', ',' });
    
                string tmp = string.Empty;
                if (numbers.Length != 1)
                {
                    if (decimalPlace <= numbers[1].Length)
                    {
                        tmp = "," + numbers[1].Substring(0, decimalPlace);
    
                        if (tmp.EndsWith(","))
                            tmp = string.Empty;
                    }
                    else
                        tmp = "," + numbers[1];
                }
                tbxConvertito.Text = numbers[0] + tmp;
    
                tbxConvertito.Select(tbxConvertito.Text.Length, 0);
            }
    
            private void tbxConvertito_TextChanged(object sender, EventArgs e)
            {
                if (keyValue == 188) return;
                if (keyPressed)
                {
                    string stringValue = tbxConvertito.Text;
                    if ((stringValue.Contains(',') && stringValue.Split(new char[] { ',' })[1].Length <= (int)numericUpDown1.Value) || !stringValue.Contains(','))
                        decimal.TryParse(tbxConvertito.Text.Replace(',', '.'), out myDecimal);
                    keyPressed = false;
                }
                numericUpDown1_ValueChanged(this, EventArgs.Empty);
                Console.WriteLine("Displayed value: {0}", tbxConvertito.Text);
                Console.WriteLine("Actual value: {0}", myDecimal);
            }
    
            bool keyPressed = false;
            int keyValue;
    
            private void tbxConvertito_KeyDown(object sender, KeyEventArgs e)
            {
                keyValue = e.KeyValue;
                keyPressed = true;
            }
        }
