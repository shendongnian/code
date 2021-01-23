      public partial class main : Form
        {
            public main()
            {
                InitializeComponent();
                Get_Frm2_Data();
            }
            private void Get_Frm2_Data()
            {
                Add_Order frm2 = new Add_Order();
                List<string> info= new List<string>;
                info.Add( frm2.textBox1.Text);
                 .
                 .
                 .
            }
        }
