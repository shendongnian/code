    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            var pn = productnames.DEVICE3; //obviously pn could be set to anything you like, or passed in to the event handler or function
            string str = textBox1.Text;
            switch (pn) 
            { 
                case productnames.DEVICE1:
                    label1.Text = str+"CASE1";
                    break;
                case productnames.DEVICE1:
                    label1.Text = str+"CASE2";
                    break;
            }
        }
    }
    
    public static class productnames
    {
        public string DEVICE1 = "name1";
        public string DEVICE2 = "name2";
        public string DEVICE3 = "name3";
        public string DEVICE4 = "name4";
    }
