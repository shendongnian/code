    private void saveData()
    {
        foreach (TextBox txt in myPlaceHolder.Controls.OfType<TextBox>())
        {
            string text = txt.Text;
            // ...
        }
    }
