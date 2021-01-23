    if (this.fSelectedButton.Equals(this.RadioButton_Delete))
    {
        this.TextBox_DestinationFile.Enabled = false;
        this.Button_DestinationBrowse.Enabled = false;
    }
    else
    {
        this.TextBox_DestinationFile.Enabled = true;
        this.Button_DestinationBrowse.Enabled = true;
    }
