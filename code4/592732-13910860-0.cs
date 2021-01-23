    public bool val2()
    {
        foreach (Control item in panel1.Controls.OfType<ComboBox>())
        {
            if (String.IsNullOrEmpty(item.Text))
                return true;
        }
        return false;
    }
    private void button2_Click(object sender, EventArgs e)
    {
        bool valo = val2();
        if (!valo)
        {
            Form4 fp = new Form4();
            fp.Show();
        }
        else
        {
            MessageBox.Show("error");
        }
    }
