        public class PhoneNumberRule
        {
            #region Fields
            static string _usPhonePattern = @"1?\W*([2-9][0-8][0-9])" +
                                            @"\W*([2-9][0-9]{2})\W*" +
                                            @"([0-9]{4})(\se?x?t?(\d*))?";
            static Regex _usPhoneRegex = new Regex( _usPhonePattern );
            #endregion Fields
            #region Methods
            
            public static void ValidateProperties( object target )
            {
                Type targetType = target.GetType( );
                var phoneNumberProperties =
                    from propertyInfo in targetType.GetProperties( )
                    where propertyInfo.GetCustomAttributes(
                        typeof( PhoneNumberAttribute ), true ).Length > 0
                    select propertyInfo;
                foreach ( PropertyInfo targetProperty in phoneNumberProperties )
                {
                    string value = targetProperty.GetValue( target, null) as string;
                    if ( value == null || !_usPhoneRegex.IsMatch( value ) )
                    {
                        ModelState[ targetProperty.Name ] = "Not a valid phone number format";
                    }
                }
            }
        }
        [AttributeUsage(AttributeTargets.Property)]
        public class PhoneNumberAttribute : Attribute
        {
        }
        public class Person
        {
            [PhoneNumber( )]
            public string HomePhone { get; set; }
        }
