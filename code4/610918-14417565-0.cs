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
               
                string[] numbers = tbxConvertito.Text.Split(new char[] { '.', ',' });
    
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
            }
    
            private void tbxConvertito_TextChanged(object sender, EventArgs e)
            {
                numericUpDown1_ValueChanged(this, EventArgs.Empty);
            }
        }
