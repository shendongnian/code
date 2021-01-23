    foreach (Control control in Form.Controls)
    {
        if (control is GroupBox)
        {
             GroupBox gb = (GroupBox)control;
             foreach (Control control in gb.Controls)
             {
                 if (control is RadioButton)
                 {
                    rb = (RadioButton)control;
                    //rb will allow you to access all of the RadioButton's properties and act accordingly.    
                    if (rb.Checked)
                    {
                        int index = int.Parse(Regex.Replace(rb.Name, "[^0-9]", "")) - 1;
                        int score;
                        if (rb.Name.Contains("ButtonSD"))
                            score = 1;
                        if (rb.Name.Contains("ButtonD"))
                            score = 2;
                        //So on...
                        score[index] = score;
                        
                    }
                 }
             }
        }
    }
