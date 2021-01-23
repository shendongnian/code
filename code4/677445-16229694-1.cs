    public static bool OnValidateMyProperty(object myObj)
            {
                if (myObj.ToString() == string.Empty)
                    **return false;**
                return true;
            }
