    private void button1_Click(object sender, EventArgs e)
    {            
        Form2 f2 = new Form2();
        f2.ShowDialog();
        while (f2.DialogResult == DialogResult.Retry)
        {
            f2 = new Form2();
            f2.ShowDialog();
        }
    }
