        public class ViewModel : BaseClass
        {
            public string Car { get; set; }
        }
        public abstract class BaseClass
        {
            public object GetField(string name)
            {
                MemberInfo member = GetType()
                    .GetMember( name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static )
                    .FirstOrDefault();
                if(member == null)
                {
                    return null;
                }
                PropertyInfo property = member as PropertyInfo;
                if(property != null)
                {
                    return property.GetValue( this, null );
                }
                FieldInfo field = member as FieldInfo;
                if(field != null)
                {
                    return field.GetValue( this );
                }
                return null;
             }
        }
