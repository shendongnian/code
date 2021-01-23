    public partial class NumberTextBox : TextBox
        {
            public NumberTextBox()
            {
                InitializeComponent();
            }
    
            private void NumberTextBox_Leave(object sender, EventArgs e)
            {
                string tTxt = ((TextBox)sender).Text;
                double tDbl;
                int tInt;
                if (tTxt == "" || !double.TryParse(tTxt, out tDbl) || !int.TryParse(tTxt, out tInt))
                {
                    ((TextBox)sender).Text = "0";
                }
            }
        }
