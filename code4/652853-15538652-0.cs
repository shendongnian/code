    public static Hashtable ConvertPropertiesAndValuesToHashtable(this object obj)
        {
            var ht = new Hashtable();
            // get all public static properties of obj type
            PropertyInfo[] propertyInfos =
                obj.GetType().GetProperties().Where(a => a.MemberType.Equals(MemberTypes.Property)).ToArray();
            // sort properties by name
            Array.Sort(propertyInfos, (propertyInfo1, propertyInfo2) => propertyInfo1.Name.CompareTo(propertyInfo2.Name));
            // write property names
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                ht.Add(propertyInfo.Name,
                       propertyInfo.GetValue(obj, BindingFlags.Public, null, null, CultureInfo.CurrentCulture));
            }
            return ht;
        }
