    you can add error message to the validation summary using the following 
 
 
    if (IsPostBack)
            {
                Page.Validate();
             var valid=   CustomValidate();
    
                  if(valid && Page.IsValid)
                     {
                     }               
            }
     
    protected bool CustomValidate()
      {
         var valid=true;
         ///do your validation here
    
         var validator = new CustomValidator();
         validator.IsValid= false;
         valid = validator.IsValid;
         Validator.ErrorMessage="Error....";        
         this.Page.Validators.Add(validator);
       return valid
     }
