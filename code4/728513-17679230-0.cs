    public string Property1
    {
        get
        {
            ErrorInfo error;
            if (errorList.TryGetValue("Property1", out error))
                return error.Value;
            return model.Property1.ToString();
        }
        set
        {
            try
            {
                model.Property1 = Double.Parse(value);
            }
            catch (Exception ex)
            {
                // Perform any view-specific actions
                errorList["Property1"] = new ErrorInfo(value, ex.Message);
            }
        }
    }
