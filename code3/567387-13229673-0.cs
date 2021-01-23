    public static **string** saveCheckBox(System.windows.Controls.CheckBox checkBox)
    {
        string status = "";
        if (checkBox.IsChecked == true)
            status = "true";
        else if (checkBox.IsChecked == false)
            status = "false";
        return status;
    }
