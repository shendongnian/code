    bool isEnabled;
    if(radioButtonList.SelectedValue = "Yes")
    {
        isEnabled = true;
    }
    CustomCode.SaveData(txBox.Text.Trim(), isEnabled);
