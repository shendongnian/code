    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false,Inherited = true)]
    public class CustomRoleAttribute : Attribute
    {
            public string Role { get; private set; }
    
            public CustomRoleAttribute(string role)
            {
                Role = role;
            }
    }
