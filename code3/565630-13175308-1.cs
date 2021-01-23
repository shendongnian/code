    foreach (Control c in this.Controls)
    {
        if ( c is IValidateMyData )
        {
            var validationResult = (c as IValidateMyData).Validate();
        }
    }
