    //Sample:
    //Assuming you are creating your labels from 
    //List<string>
   
     List<string> labels=new List<string>();
        labels.Add("If");
        labels.Add("variable");
        labels.Add("=");
        labels.Add("5");
        for (int i = 0; i < labels.Count; i++)
        {
            Label lbl = new Label();
            lbl.Text = labels[i];
            flowLayoutPanel1.Controls.Add(lbl);
        }
            
            }
