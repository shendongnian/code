    public partial class ParentForm : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            ChildForm child = new ChildForm();
    
            child.FormClosing += new FormClosingEventHandler(child_FormClosing);
            Hide();
            child.Show();
        }
    
        private void child_FormClosing(object sender, FormClosingEventArgs e)
        {
            Show();
        }
    }
