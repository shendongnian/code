    // Value converter class that does the conversion work.
    public class EnumToDescAttrConverter : IValueConverter
    {
        // Derived Grant Barrintgon's blog on C#.
 
        /// <summary>
        /// Extension method that retrieves the description attribute for a particular enum value.
        /// [Description("Bright Pink")]
        /// BrightPink = 2,
        /// </summary>
        /// <param name="en">The Enumeration</param>
        /// <returns>A string representing the friendly name</returns>
        public string GetDescription(Enum en)
        {
            Type type = en.GetType();
 
            MemberInfo[] memInfo = type.GetMember(en.ToString());
 
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
 
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
 
            // Unable to find a description attribute for the enum.  Just return the
            //  value of the ToString() method.
            return en.ToString();
        }
 
        // Consumer wants to convert an enum to a description attribute string.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Since we don't know what the correct default value should be, a NULL value is unacceptable.
            if (value == null)
                throw new ArgumentNullException("(EnumToDescAttrConverter:Convert) The value is unassigned.");
 
            Enum e = (Enum)value;
 
            return e.GetDescription();
        } // public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
 
        // Convert an enumeration value in Description attribute form back to the appropriate enum value.
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Since we don't know what the correct default value should be, a NULL value is unacceptable.
            if (value == null)
                throw new ArgumentNullException("(EnumToDescAttrConverter:ConvertBack) The value is unassigned.");
 
            string strValue = (string)value;
 
            // Parameter parameter must be set since it must contain the concrete Enum class name.
            if (parameter == null)
                throw new ArgumentNullException("(EnumToDescAttrConverter:ConvertBack) The Parameter parameter is unassigned.");
 
            string theEnumClassName = parameter.ToString();
 
            // Create an instance of the concrete enumeration class from the given class name.
            Enum e = (Enum)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(theEnumClassName);
 
            if (e == null)
                throw new ArgumentException(
                    "(EnumToDescAttrConverter:ConvertBack) Invalid enumeration class name: " + theEnumClassName
                    + ". Set a break point here and call System.Reflection.Assembly.GetExecutingAssembly().DefinedTypes.ToList()"
                    + " in the immediate window to find the right type.  Put that type into the Converter parameter for the"
                    + " data bound element you are working with."
                    );
 
            System.Type theEnumType = e.GetType();
 
            Enum eRet = null;
 
            foreach (MemberInfo memInfo in theEnumType.GetMembers())
            {
                object[] attrs = memInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
 
                if (attrs != null && attrs.Length > 0)
                {
                    if (((DescriptionAttribute)attrs[0]).Description == strValue)
                    {
                        // Ignore the case
                        eRet = (Enum)Enum.Parse(theEnumType, memInfo.Name, true);
                        break; // Found it.
                    }
                }
            } // foreach (MemberInfo memInfo in typeof(TEnum).GetMembers())
 
            // If the string can not be converted to a valid enum value, throw an
            //  Exception.
            if (eRet == null)
                throw new ArgumentException(String.Format("{0} can not be converted to an enum value: ", strValue));
 
            return eRet;
        } // public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
 
        /// <summary>
        ///  Returns all the values for given Enum as a list of their string attributes.  <br />
        ///   Use this method to fill a list box with human friendly strings for each <br />
        ///   enumeration value using the DescriptionAttribute() associated it/them.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>An enumerator for the Enum values</returns>
        public static List<string> ToDescriptionsList<T>()
        {
            // GetValues() is not available on Windows Phone.
            // return Enum.GetValues(typeof(T)).Cast<T>();
            List<string> listRet = new List<string>();
 
            foreach (var x in typeof(T).GetFields())
            {
                Enum e;
 
                if (x.IsLiteral)
                {
                    e = (Enum)x.GetValue(typeof(Enum));
 
                    listRet.Add(e.GetDescription());
                } // if (x.IsLiteral)
            } // foreach()
 
            return listRet;
        } // public static IEnumerable<T> GetValues<T>(this T theEnum)    } // public class EnumToDescAttrConverter : IValueConverter
    } // public class EnumToDescAttrConverter : IValueConverter
