    public partial class Form1 : Form
    {
    public Form1()
    {
        InitializeComponent();
        IsMdiContainer = true;
    }
    public void CreateMdiChild<T>() where T : Form, new()
    {
        foreach (Form frm in this.MdiChildren)
        {
            if (frm.GetType() == typeof(T))
            {
                if (frm.WindowState == FormWindowState.Minimized)
                {
                    frm.WindowState = FormWindowState.Normal;
                }
                else
                {
                    frm.Activate();
                }
                return;
            }
        }
        T t = new T();
        t.MdiParent = this;
        t.Show();
    }
    private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CreateMdiChild<Form2>();
    }
