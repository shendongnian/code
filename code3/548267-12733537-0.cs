        public class ViewModel : BaseClass
        {
            public string Car { get; set; }
        }
        public abstract class BaseClass
        {
            public object GetField(string name)
            {
                var member = GetType()
                    .GetMember( name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static )
                    .FirstOrDefault();
                if(member == null)
                {
                    return null;
                }
                var property = member as PropertyInfo;
                if(property != null)
                {
                    var getMethod = property.GetGetMethod( false ) ?? property.GetGetMethod( true );
                    if(getMethod == null)
                    {
                        return null;
                    }
                    return getMethod.Invoke( this, null );
                }
                var field = member as FieldInfo;
                if(field != null)
                {
                    return field.GetValue( this );
                }
                return null;
             }
        }
