    namespace Forums.LinqToValidatePhoneNumberProperty
    {
        using System;
        using System.Linq;
        using System.Reflection;
        using System.Text.RegularExpressions;
        public class PhoneNumberRule
        {
            #region Fields
            static string _usPhonePattern = @"1?\W*([2-9][0-8][0-9])" +
                                            @"\W*([2-9][0-9]{2})\W*" +
                                            @"([0-9]{4})(\se?x?t?(\d*))?";
            static Regex _usPhoneRegex = new Regex( _usPhonePattern );
            #endregion Fields
            #region Methods
            public static void Validate( object target, string propertyName )
            {
                Type targetType = target.GetType();
                PropertyInfo targetProperty = 
                    ( from propertyInfo in targetType.GetProperties()
                    where ( propertyInfo.Name == propertyName
                    && propertyInfo.PropertyType.IsAssignableFrom(  
                        typeof (string ) ) )
                    select propertyInfo ).First();
                if ( targetProperty == null )
                {
                    throw new InvalidOperationException( "No appropriate property " +
                                                         "could be found on the " + 
                                                         "target object." );
                }
                string testValue = targetProperty.GetValue( target, null ) as string;
                if ( testValue != null && _usPhoneRegex.IsMatch( testValue ) )
                {
                    return;
                }
                else
                {
                    ModelState[propertyName] = "Not a valid phone number format";
                }
            }
            #endregion Methods
        }
    }
