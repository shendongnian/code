    foreach (Control c in groupBox1.Controls)
                {
                    if (c.GetType() == typeof(RadioButton))
                    {
                        RadioButton rb = c as RadioButton;
                        if (rb.Checked)
                        {
                           //here you can either store the checked radio button in a variable to further check the color you need to set, or do the logic here.
                        }
                    }
                }
    }
 
