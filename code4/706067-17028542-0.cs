    public partial class Form1 : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is Form2)
                {
                    frm.Show();
                    return;
                }
            }
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
