    private void MyButton_KeyPress(object sender, KeyPressEventArgs e
    {
        int i = 0;
        if (!int.TryParse(e.KeyChar.ToString(), out i))
        {
            if (e.KeyChar.CompareTo('-')!=0)
            {
                e.Handled = true;
            }
        }
    }
