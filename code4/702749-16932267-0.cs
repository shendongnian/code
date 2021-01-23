        public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
                }
        
       protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
                {
        
                    if (keyData == (Keys.LWin | Keys.Up))//Left windows key + up arrow
                    {
                        
                        FormBorderStyle = FormBorderStyle.FixedDialog;
                        return true;
                    }
                    //Form will call its close method when we click Escape.
                    if (keyData == Keys.Escape){}
                        Close();
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
