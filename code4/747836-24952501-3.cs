    public class
    {
        AuditClass.AuditingUserActivity(OldObject,ChangedObject);   
    }
    class AuditClass
    {
        public static void AuditingUserActivity<T>(this T obj1,obj2)
        {
            PropertyInfo[] properties = typeof(T).GetProperties(); //Gets all properties exist in passed objects of both
           
            foreach (PropertyInfo pi in properties)
            {
                object value1 = typeof(T).GetProperty(pi.Name).GetValue(obj1, null); // gets value for each entity
                object value2 = typeof(T).GetProperty(pi.Name).GetValue(obj2, null);
                if (value1 != null && value2 != null)
                {
                    //You can compare and check whether changes made or not
                }
            }
        }             
    }
