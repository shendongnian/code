    bool? IsYes;
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex != -1)
        {
            //IsYes = comboBox1.SelectedIndex == 0;
            choosewhatyouwanttobuyLabel.Visible = comboBox1.SelectedIndex == 0;
        }
        else
        {
            IsYes = null;
        }
    }
