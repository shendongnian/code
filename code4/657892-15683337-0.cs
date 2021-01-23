    private void checkbox_Paint(object sender, PaintEventArgs e)
    {
        var checkbox = sender as CheckBox // Here you get the current checkbox
        Rectangle rect = new Rectangle(0, 0, 16, 16);
		if (checkbox.Checked)
        {
            e.Graphics.DrawImage(Properties.Resources.checkbox_checked, rect);
        }
        else
        {
            e.Graphics.DrawImage(Properties.Resources.checkbox_unchecked, rect);
        }
    }
