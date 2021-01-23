    public static bool HasProperty(dynamic obj, string name)
        {
            try
            {
                var value = obj[name];
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }
