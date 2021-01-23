    public static bool PropertyHasValue(object obj, string propertyName, string propertyValue)
    {
        try
        {
            if(obj != null)
            {
                PropertyInfo prop = obj.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
                if(prop != null)
                {
                    object val = prop.GetValue(obj,null);
                    string sVal = Convert.ToString(val);
                    if(sVal == propertyValue)
                    {
                        Debug.Log (obj.GetType().FullName + "Has the Value" + propertyValue);
                        return true;    
                    }
                }
            }
    
            Debug.Log ("No property with this value");
            return false;
        }
        catch
        {
            Debug.Log ("An error occurred.");
            return false;
        }
    }
