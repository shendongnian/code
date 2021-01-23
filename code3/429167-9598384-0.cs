        /// <summary>
        /// Returns the string value defined by the description attribute of the given enum.
        /// If no description attribute is available, then it returns the string representation of the enum.
        /// </summary>
        /// <param name="value">Enum to use</param>
        /// <returns>String representation of enum using Description attribute where possible</returns>
        public static string StringValueOf(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }
