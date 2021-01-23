    enum ValidationType{
        NullCheck,
        IsNumber,
        RangeCheck,
        ....
    }
    class ErrorMessages{
        const string FNEMPTY = "First Name is empty";
        ....
    }
    class BusinessObject{
        function ValidateControl(Control cntrl, ValidationType type, object[] args, string message)
        {
            if(cntrl is TextBox)
            {
                 if(cntrl as TextBox).Text.Trim() == String.Empty
                      errorMessages.Add(message);
            }
            ...
        }
    }
