    // psuedocode:
    foreach( Control ctl in myForm.Controls )
    {
        if( ctl is TextBox )
        {
            ((TextBox)ctl).TextChanged += UpdateIsDirtyHandler;
        }
        if( ctl is ComboBox )  { ... }
          // etc...
    }
