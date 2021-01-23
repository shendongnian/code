     public string ToString(this object value)
    {
        Try 
        {
            // this will throw an exception if value is null
            String val = Convert.ToString (value);
            
            // it can be a space
            If (string.IsNullOrEmpty(val.Trim()) 
                return string.Empty:
        }
        catch (NullreferenceException excep)
        {
            return string.Empty;
        }
        // to avoid not all code paths return a value
        return val;
}
