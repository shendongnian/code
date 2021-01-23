     /// <summary>
        /// Copies all the properties of the "from" object to this object if they exist.
        /// </summary>
        /// <param name="to">The object in which the properties are copied</param>
        /// <param name="from">The object which is used as a source</param>
        /// <param name="excludedProperties">Exclude these properties from the copy</param>
        public static void copyPropertiesFrom
    	(this object to, object from, string[] excludedProperties)
        {
          Type targetType = to.GetType();
          Type sourceType = from.GetType();
     
          PropertyInfo[] sourceProps = sourceType.GetProperties();
          foreach (var propInfo in sourceProps)
          {
            //filter the properties
            if (excludedProperties != null
              && excludedProperties.Contains(propInfo.Name))
              continue;
     
            //Get the matching property from the target
            PropertyInfo toProp =
              (targetType == sourceType) ? propInfo : targetType.GetProperty(propInfo.Name);
     
            //If it exists and it's writeable
            if (toProp != null && toProp.CanWrite)
            {
              //Copy the value from the source to the target
              Object value = propInfo.GetValue(from, null);
              toProp.SetValue(to,value , null);
            }
          }
        }
