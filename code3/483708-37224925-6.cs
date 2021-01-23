    public partial class MyForm : Form
    {
        MessageFilter mf = null;
        private void MyForm_Load(object sender, EventArgs e)
        {
            mf= new MessageFilter();
            Application.AddMessageFilter(mf);
        }
        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.RemoveMessageFilter(mf);
        }
    }
