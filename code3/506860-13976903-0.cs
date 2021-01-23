        public static class SerializationHelpers
        {
          /// <summary>
          /// Copy all public props and fields that are not xmlignore
          /// </summary>
          /// <typeparam name="T"></typeparam>
          /// <param name="target"></param>
          /// <param name="other"></param>
          public static void CopyTypeFields<T>(T target, T other)
          {
            // get all public static properties of MyClass type
            PropertyInfo[] propertyInfos = other.GetType().GetProperties(BindingFlags.Public  
            | BindingFlags.Instance);
            FieldInfo[] fis = other.GetType().GetFields(BindingFlags.Public | 
            BindingFlags.Instance);
            foreach (FieldInfo fi in fis)
            {
              if ((fi.Attributes & FieldAttributes.FieldAccessMask) != 
                  FieldAttributes.Literal &&
                  (fi.Attributes & FieldAttributes.FieldAccessMask) != 
                  FieldAttributes.Static)
              {
                if (IsXmlIgnored(fi)) { continue; }
                var myval = fi.GetValue(other);
                fi.SetValue(target, myval);
              }
            }
            
            foreach (PropertyInfo pi in propertyInfos)
            {
              if (!pi.CanWrite || !pi.CanRead) { continue; }
              if (IsXmlIgnored(pi)) { continue; }
              var myval = pi.GetValue(other, null);
              pi.SetValue(target, myval, null);
            }
          }
          private static bool IsXmlIgnored(MemberInfo pi)
          {
            object[] fiGetCustomAttributes = pi.GetCustomAttributes(false);
            foreach (object ob in fiGetCustomAttributes)
            {
              if (ob.GetType().
                  Equals(typeof(System.Xml.Serialization.XmlIgnoreAttribute)))
              {
                return true;
              }
            }
            return false;
          }
        }
        // to use it ...
        // the deserialization method of the singleton mySingleton
        public bool loadSingleton()
        {
          bool ret= false;
          try
          {
            Type myType = GetType();
            XmlSerializer reader = new XmlSerializer(myType);
            try
            {
              using (StreamReader file = new StreamReader(filename))
              {
                try
                {
                  mySingleton t1 = (mySingleton)reader.Deserialize(file);
                  CopySerializationFields(t1);
                  ret= true;
                }
                catch
                {
                  ...
                }
              }
            }
            catch
            {
              ...
            }
          }
          catch (Exception ex)
          {
            ...
          }
          return ret;
        }
        private void CopySerializationFields(ProcessingSettings other)
        {
          SerializationHelpers.CopyTypeFields(this, other);
        }
