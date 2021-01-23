    public partial class Form1
    {
       private decimal _oldValue;
       private TextBox textBox;
       
       public Form1()
       {
          InitializeComponent();
          textBox = (TextBox)numericUpDown.Controls[1];
          textBox.TextChanged += TextBoxOnTextChanged;
       }
       private void TextBoxOnTextChanged(object sender, EventArgs eventArgs)
        {
            decimal newValue = Convert.ToDecimal(((TextBox) sender).Text);
            if (newValue > numericUpDown.Maximum || newValue < numericUpDown.Minimum)
                ((TextBox) sender).Text = _oldValue.ToString();
        }
       private void numericUpDown_KeyDown(object sender, KeyEventArgs e)
       {
          _oldValue = ((NumericUpDownCustom) sender).Value;
       }
    }
