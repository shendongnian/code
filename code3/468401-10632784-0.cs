    private void TrimTextBoxes(DependencyObject depObject)
    {
        if (depObject is TextBox)
        {
            TextBox txt = depObject as TextBox;
            txt.Text = txt.Text.Trim();
        }
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObject); i++)
        {
            TrimTextBoxes(VisualTreeHelper.GetChild(depObject, i));
        }
    }
