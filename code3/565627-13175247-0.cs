    foreach (Control c in this.Controls)
    {
      IValidate validateControl = c as IValidate;
      if(validateControl != null)
      {
           // do the validation.
      }
     
