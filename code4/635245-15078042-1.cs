    public void OnClick(object sender, EventArgs eargs)
    {
        float e = (float)Convert.ToDouble(e_textBox.Text);
        bool valid = float.TryParse(e_textBox.Text.ToString(), out e);
    }
