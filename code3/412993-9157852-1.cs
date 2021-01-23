    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form2 : Form
        {
            public Form1 Form1Instance;
            public Form2()
            {
                InitializeComponent();
            }
    
            private void btnSortValues_Click(object sender, EventArgs e)
            {
                Form1Instance.rglu = glu;
                Form1Instance.rdate = fulldate;
                Form1Instance.sort();
                Close();
            }
        }
    }
