    public partial class Form1 : Form
    {
        char[] operators;
        public Form1()
        {
            InitializeComponent();
            Form2 frm2 = new Form2();
            if (frm2.ShowDialog() == DialogResult.OK) //Check for DialogResult Here
            {
                operators = CreateArray(frm2.GetOperators); // Get ComboBox Values from Form2 and Process them
                frm2.Close();                  // Close Form2
            }
            else
                Application.Exit();           // If DialogResult is not OK then exit Form
        }
        private char[] CreateArray( int value)
        {
            string num = "";
            if ((value & 1) == 1)
                num += "+";
            if ((value & 2) == 2)
                num += "-";
            if ((value & 4) == 4)
                num += "*";
            if ((value & 8) == 8)
                num += "/";
            if ((value & 16) == 16)
                num += "%";
            return num.ToCharArray();
        }
    }
