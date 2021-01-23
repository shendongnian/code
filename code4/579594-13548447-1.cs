    public partial class Form2 : Form
    {
        int operators;
        public Form2()
        {
            InitializeComponent();
        }
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            //Method that I used for determining CheckBox State. You can use a boolean array or an Enumeration ....
            if (cb.Text == "Addition")
                operators = operators ^ 1;
            else if (cb.Text == "Subtraction")
                operators = operators ^ 2;
            else if (cb.Text == "Multiplication")
                operators = operators ^ 4;
            else if (cb.Text == "Division")
                operators = operators ^ 8;
            else if (cb.Text == "Modulus")
                operators = operators ^ 16;
        }
        public  int GetOperators       //Property for return value to Form1
        {
            get { return operators; }
        }
    }
