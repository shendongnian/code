    public partial class Form1 : Form
    {
        static int i = 0;
        public Form1()
        {
            InitializeComponent();
            foreach (RowContent ctrl in userControl11.tableLayoutPanel1.Controls)
            {
                ctrl.SetChkBox1Text = i.ToString();
                if (!ctrl.IsEnabledChecked && i % 2 == 0)
                    ctrl.IsEnabledChecked = true;
                i++;
            }
            foreach (RowContent ctrl in userControl12.tableLayoutPanel1.Controls)
            {
                ctrl.SetChkBox1Text = i.ToString();
                i++;
            }
        }
    }
