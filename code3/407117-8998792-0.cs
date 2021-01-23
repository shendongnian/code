    public string this[string columnName]
    {
        get
        {
            if (columnName == "Number")
            {
                if (Number == null) return "Invalid number";
            }
            return null;
        }
    }
