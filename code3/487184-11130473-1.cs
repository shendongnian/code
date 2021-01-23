    bool[] check_list = new bool[] { true, true, false };
    private void button3_Click(object sender, EventArgs e)
    {
        foreach (Control c in groupBox1.Controls)
        {
            if (c is CheckBox)
            {
                CheckBox current = c as CheckBox;
                current.Checked = check_list[int.Parse(current.Tag.ToString())];
            }
        }
    }
