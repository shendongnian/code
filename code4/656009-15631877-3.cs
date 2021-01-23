    using System;
    using System.Windows.Forms;
    
    namespace SOF_15631067
    {
        public partial class UserControl1 
            : UserControl
        {
            public UserControl1()
            {
                InitializeComponent();
            }
        private void UserControl1_Load(object sender, EventArgs e)
        {
        }
        public void MinimMaxim()
        {
            _txtName.Visible = true;
            _txtPackage.Visible = true;
            _panelButton.Visible = false;
            _txtBody.Visible = false;
            _btnPlus.Visible = false;
        } 
    }
