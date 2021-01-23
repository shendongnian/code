    private void Calculate_button_Click(object sender, EventArgs e)
    {
        RadioButton[] newRadioButtons = { radiobutton1, radiobutton2, radiobutton3 };
        for (int inti = 0; inti < newRadioButtons.Length; inti++)
        {
            if (newRadioButton[inti].Checked == false)
            {
                MessageBox.Show("Please check the radio button");
                newRadioButtons[inti].Focus();
                return;
            }
        }
        TextBox[] newTextBox = { txtbox1, txtbox2, txtbox3, txtbox4, txtbox5 };
        for (int inti = 0; inti < newRadioButtons.Length; inti++)
        {
            if (newTextBox[inti].text == string.Empty)
            {
                MessageBox.Show("Please fill the text box");
                newTextBox[inti].Focus();
                return;
            }
        }
    }
    
