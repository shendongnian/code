    private void TextboxPlaceHolder(Control control, string PlaceHolderText)
    {
            control.Text = PlaceHolderText;
            control.GotFocus += delegate (object sender, EventArgs args)
            {
                if (cusmode == false)
                {
                    control.Text = control.Text == PlaceHolderText ? string.Empty : control.Text;
                    //IF Focus TextBox forecolor Black
                    control.ForeColor = Color.Black;
                }
            };
            control.LostFocus += delegate (object sender, EventArgs args)
            {
                if (string.IsNullOrWhiteSpace(control.Text) == true)
                {
                    control.Text = PlaceHolderText;
                    //If not focus TextBox forecolor to gray
                    control.ForeColor = Color.Gray;
                }
            };
    }
