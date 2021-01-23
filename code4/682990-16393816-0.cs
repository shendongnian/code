    protected void CheckBoxDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CheckBox chk = e.Source as CheckBox;
            if (chk != null)
            {
                chk.Content = "Content Changed";
            }
        }
