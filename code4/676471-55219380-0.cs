        public static bool GetBoolValue(string featureKeyValue)
        {
            if (!string.IsNullOrEmpty(featureKeyValue))
            {
                        try 
                        {
                            bool value;
                            if (bool.TryParse(featureKeyValue, out value))
                            {
                                return value;
                            }
                            else
                            {
                                return Convert.ToBoolean(Convert.ToInt32(featureKeyValue));
                            }
                        }
                        catch
                        {
                            return false;
                        }
             }
             else
             {
                      return false;
             }
       }
