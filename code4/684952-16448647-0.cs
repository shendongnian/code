    public class MyForm : Form
    {
        private Form5 m_frm5 = null;
        // ...other code...
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_frm5 == null)
            {
                m_frm5 = new Form5();
            }
            m_frm5.Show();
        }
    }
    
