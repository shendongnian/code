    public static string SqlConnectionToConnectionString(SqlConnection conn)
    {
    	System.Reflection.PropertyInfo property = conn.GetType().GetProperty("ConnectionOptions", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
    	object optionsObject = property.GetValue(conn, null);
    	System.Reflection.MethodInfo method = optionsObject.GetType().GetMethod("UsersConnectionString");
    	string connStr = method.Invoke(optionsObject, new object[] { false }) as string; // argument is "hidePassword" so we set it to false
    	return connStr;
    }
