        void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton senderRadioButton = sender as RadioButton;
            if (senderRadioButton.Equals(DoctorRadioButton))
            // OR senderRadioButton.Name == "DoctorRadioButton"
            {
                // Place your code here for DoctorRadioButton.
            }
            else
            {
                // Place your code here for PatientRadioButton.
            }
        }
