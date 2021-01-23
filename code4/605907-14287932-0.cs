    namespace ModalTest
    {
        using System;
        using System.Windows.Forms;
    
        public partial class frmMain : Form
        {
            frmEmployees frmEmp = new frmEmployees();
            frmNewEmployee frmNE = new frmNewEmployee();
    
            public frmMain()
            {
                InitializeComponent();
                IsMdiContainer = true;
            }
    
            private void btnGo_Click(object sender, EventArgs e)
            {
                frmEmp.MdiParent = this;
                frmEmp.Show();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                frmNE.MdiParent = frmEmp.MdiParent;
                frmEmp.Hide();
                frmNE.Show();
            }
        }
    }
