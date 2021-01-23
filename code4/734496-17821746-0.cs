    public override bool IsValid(object value)
    {
        if (value != null)
        {
            try
            {
                DateTime date = DateTime.Parse(value.ToString());
                return true;
            }
            catch (ArgumentNullException)
            {
                // value is null so not a valid string
            }
            catch (FormatException)
            {
                //not a valid string
            }
        }
        return false;
    }
