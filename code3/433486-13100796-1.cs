    foreach (var control in groupBox3.Controls)
    {                
        RadioButton radio = control as RadioButton;
    
        if (radio != null && radio.Checked)
        {
            var a = radio.Name;   //it gives the name of radio button is checked
        }
    }
