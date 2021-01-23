    foreach (Control c in cblCRMStatus.Controls)
    {
       CheckBox cb = c as CheckBox;
       if(cb != null)
       {
           cb.Attributes.Add("data-MyField", myFieldVal);
       }
    }
    
