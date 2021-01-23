    foreach (Control c in this.Controls)
    {
      IValidatable validateControl = c as IValidatable;
      if(validateControl != null)
      {
           // do the validation.
           validateControl.Validates();
      }
     
