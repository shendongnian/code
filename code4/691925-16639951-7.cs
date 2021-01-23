    public List<string> GetValues(Type enumType)
    {   
        if(typeof(Enum).IsAssignableFrom(enumType))
        {
            Array names = Enum.GetNames(enumType);
    		Array values = Enum.GetValues(enumType);
    		
    		List<string> result = new List<string>(capacity:names.Length);
    		
            for (int i = 0; i < names.Length; i++)
            {
                result.Add(string.Format("Value {0} Name {1}", 
    			                        (int)values.GetValue(i), names.GetValue(i)));
            }
            return result;
        }
        throw new ArgumentException("enumType");
    }
