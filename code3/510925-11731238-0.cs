        string System.ComponentModel.IDataErrorInfo.this[string columnName]
        {
            get
            {
                switch (columnName.ToLower())
                {
                    case "code":
                        if (string.IsNullOrWhiteSpace(this.Code)) return "Required field";
                        break;
                    case "name":
                        if (string.IsNullOrWhiteSpace(this.Name)) return "Required field";
                        break;
                }
                return null;
            }
        }
