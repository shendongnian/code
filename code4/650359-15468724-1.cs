    void checkBox_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cb = (CheckBox)sender;
        switch(cb.Name)
        {
            case "checkBox1":
                if (cb.Checked)
                    // Method to use when checkBox1 is checked
                else
                    // Method to use when checkBox1 is unchecked
                break;
            case "checkBox2":
                if (cb.Checked)
                    // Method to use when checkBox2 is checked
                else
                    // Method to use when checkBox2 is unchecked
                break;
            case "checkBox3":
                if (cb.Checked)
                    // Method to use when checkBox3 is checked
                else
                    // Method to use when checkBox3 is unchecked
                break;
            default:
                break;
            //Implement your other checkBox's the same way.
            }
           
        }
