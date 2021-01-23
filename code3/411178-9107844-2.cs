    private bool IsValidInput(string p)
    {
        switch (this.Type)
        {
            case NumericTextBoxType.Float:
                double doubleResult;
                return double.TryParse(p, out doubleResult);
            case NumericTextBoxType.Integer:                    
            default:
                int intResult;
                return int.TryParse(p, out intResult);
        }
    }
