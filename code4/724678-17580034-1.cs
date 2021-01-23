    /// <summary>
      /// returns default value for the passed type
      /// / See http://stackoverflow.com/questions/325426/programmatic-equivalent-of-defaulttype
      /// </summary>
      /// <param name="t"></param>
      /// <returns></returns>
      public static object GetDefault(Type t)
      {
         if (t.IsValueType)
         {
            return Activator.CreateInstance(t);
         }
         return null;
      }
      /// <summary>
      /// Compare string with object (Rob Jasinski)
      /// </summary>
      /// <param name="stringValue"></param>
      /// <param name="objectValue"></param>
      /// <param name="objectType"></param>
      /// <returns></returns>
      public static bool StringEquals(this String stringValue, object objectValue, Type objectType)
      {
         object convertedStringValue = GetDefault(objectType);
         if (!string.IsNullOrWhiteSpace(stringValue))
            convertedStringValue = Convert.ChangeType(stringValue, objectType);
         return object.Equals(convertedStringValue, objectValue);
      }
