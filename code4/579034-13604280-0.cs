     public Boolean IsModelValid()
        {
            Boolean isValid = true;
            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo p in properties)
            {
                if (!p.CanWrite || !p.CanRead)
                {
                    continue;
                }
                if (this[p.Name] != null)
                {
                    isValid = false;
                }
            }
            return isValid;
        }
