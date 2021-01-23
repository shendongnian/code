    public string this[string columnName]
            {
                get
                {
                    if (string.Equals(columnName, "PartNumber", StringComparison.OrdinalIgnoreCase) || columnName == string.Empty)
                    {
                        // Here, IDataErrorInfo is checking the property "PartNumber" bound to your TextBox
                        if (this.IsPartNumberValid(ui_partNumber.Text))
                        {
                            // Not valid: return any error message (string.Empty = no error, otherwise it will be seen as not valid)
                            return "Not valid!";
                        }
                    }
                    return string.Empty;
                }
            }
