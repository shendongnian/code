    public class BaseEntity
    {
        public BaseEntity()
        {
            if (GetType().IsSubclassOf(typeof(BaseEntity)))
            {
                var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
    
                foreach (var property in properties)
                {
                    // Get only string properties
                    if (property.PropertyType != typeof (string))
                    {
                        continue;
                    }
    
                    if (!property.CanWrite || !property.CanRead)
                    {
                        continue;
                    }
    
                    if (property.GetGetMethod(false) == null)
                    {
                        continue;
                    }
                    if (property.GetSetMethod(false) == null)
                    {
                        continue;
                    }
    
                    if (string.IsNullOrEmpty((string) property.GetValue(this, null)))
                    {
                        property.SetValue(this, string.Empty, null);
                    }
                }
            }
        }
    }
    public class CaseOfficer : BaseEntity
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
