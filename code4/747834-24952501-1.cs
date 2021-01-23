    public static void AuditingUserActivity<T>(this T obj1,obj2)
        {
            PropertyInfo[] properties = typeof(T).GetProperties(); //Takes all properties
           
                foreach (PropertyInfo pi in properties)
                {
                    try
                    {
                        object value1 = typeof(T).GetProperty(pi.Name).GetValue(obj1, null); 
                        object value2 = typeof(T).GetProperty(pi.Name).GetValue(obj2, null);
                        if (value1 != null && value2 != null)
                        {
                            //Do Something to changes occured
                        }'
