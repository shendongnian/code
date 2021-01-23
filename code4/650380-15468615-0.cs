    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.NumPad1: 
                Toggle(checkBox1); break;
            case Keys.NumPad2:
                Toggle(checkBox2); break;
            case Keys.NumPad3:
                Toggle(checkBox3); break;
            ...
            default:
                break;
        }
    }
    private void Toggle(CheckBox checkbox)
    {
        checkbox.Checked = !checkbox.Checked;
    }
