    public void radiobutton_CheckedChanged(object sender, EventArgs e)
    {
        checkBox2_CheckedChanged(s,e);
    }
    private void checkBox2_CheckedChanged(object sender,EventArgs e)
    {
        if (checkBox2.Checked)
        {
            textBox.Text = radiobutton.Text;
        }
    }
