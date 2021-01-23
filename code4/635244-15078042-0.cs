    public void OnClick(object sender, EventArgs e)
    {
        float e = (float)Convert.ToDouble(e_textBox.Text);
        bool valid = float.TryParse(e_textBox.Text.ToString(), out e);
    }
