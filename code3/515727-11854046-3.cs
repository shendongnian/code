    private void button1_Click(object sender, EventArgs e)
    {
        using (ContactForm frm = new ContactForm(m_customers))
        {
            frm.ShowDialog();
        }
    }
