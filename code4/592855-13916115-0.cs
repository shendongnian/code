    using System.Windows.Forms;
    
    namespace WindowsFormsApplication5
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
                KeyPreview = true;
            }
    
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                switch (keyData)
                {
                    case Keys.Left:
                        // while Left is down
                        // call this method repeadetdly
                        MessageBox.Show("its left", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // when key is up stop calling this method
                        // and check for other keys
                        return true;
    
                    default:
                        return false;
                }
            }
        }
    }
