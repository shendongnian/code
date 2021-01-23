    private bool TryGetValue<U>(string key, out U value)
        {
            object cachedValue = HttpContext.Current.Cache.Get(key);
            if (cachedValue == null)
            {
                value = default(U);
                return false;
            }
            else
            {
                try
                {
                    value = (U)cachedValue;
                    return true;
                }
                catch
                {
                    value = default(U);
                    return false;
                }
            }
        }
 
