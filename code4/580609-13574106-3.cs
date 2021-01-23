    var resultList = new List<KeyValuePair<string, int>>();
    
    foreach (var control in this.Controls)
    {
        if (control is GroupBox)
        {
             GroupBox gb = (GroupBox)control;
             foreach (Control controll in gb.Controls)
             {
                 if (controll is RadioButton)
                 {
                    RadioButton rb = new RadioButton();
                    rb = (RadioButton)controll;
                    //rb will allow you to access all of the RadioButton's properties and act accordingly.    
                    if (rb.Checked)
                    {
                        int score;
                        if (rb.Name.Contains("ButtonSD"))
                            score = 1;
                        if (rb.Name.Contains("ButtonD"))
                            score = 2;
                        //So on...
                        resultList.Add(new KeyValuePair<string, int>(gb.Name, score));
                        
                    }
                 }
             }
        }
    }
