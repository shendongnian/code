    string sGender;
    var radioButton = groupBox4.Controls.OfType<RadioButton>().Where(r => r.Checked).FirstOrDefault();
    if (radioButton == null)
    {
        sGender = "";
    }
    else
    {
        sGender = radioButton.Tag.ToString()
    }
