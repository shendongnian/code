    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                IsMdiContainer = true;
            }
            Form2 frm2;
            public void CreateMdiChild<T>(ref T t) where T : Form, new()
            {
                if (t == null || t.IsDisposed)
                {
                    t = new T();
                    t.MdiParent = this;
                    t.Show();
                }
                else
                {
                    if (t.WindowState == FormWindowState.Minimized)
                    {
                        t.WindowState = FormWindowState.Normal;
                    }
                    else
                    {
                        t.Activate();
                    }
                }
            }
            private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
            {
                CreateMdiChild<Form2>(ref frm2);
            }
        }
    
