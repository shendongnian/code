    public partial class Form1 : Form
    {
            public decimal myDecimal = 3755.25012345M;
    
            public Form1()
            {
                InitializeComponent();
    
                tbxConvertito.Text = myDecimal.ToString();
    
                numericUpDown1_ValueChanged(this, EventArgs.Empty);
            }
    
            private void numericUpDown1_ValueChanged(object sender, EventArgs e)
            {          
                int decimalPlace = (int)numericUpDown1.Value;
                tbxConvertito.Text = Decimal.Round(myDecimal, decimalPlace).ToString();
            }
    }
