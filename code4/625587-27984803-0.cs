    class TitleCaseMap<T> : SqlMapper.ITypeMap where T: new()
    {
        ConstructorInfo SqlMapper.ITypeMap.FindConstructor(string[] names, Type[] types)
        {
            return typeof(T).GetConstructor(Type.EmptyTypes);
        }
        SqlMapper.IMemberMap SqlMapper.ITypeMap.GetConstructorParameter(ConstructorInfo constructor, string columnName)
        {
            return null;
        }
        SqlMapper.IMemberMap SqlMapper.ITypeMap.GetMember(string columnName)
        {
            string reformattedColumnName = string.Empty;
            foreach (string word in columnName.Replace("_", " ").Split(new[] {' '}))
            {
                if (word.Length == 0)
                {
                    continue;
                }
                reformattedColumnName += word.Substring(0, 1).ToUpper();
                if (word.Length > 1)
                {
                    reformattedColumnName += word.Substring(1);
                }
            }
            var prop = typeof(T).GetProperty(reformattedColumnName);
            return prop == null ? null : new PropertyMemberMap(prop);
        }
        class PropertyMemberMap : SqlMapper.IMemberMap
        {
            private readonly PropertyInfo _property;
            public PropertyMemberMap(PropertyInfo property)
            {
                _property = property;
            }
            string SqlMapper.IMemberMap.ColumnName
            {
                get { throw new NotImplementedException(); }
            }
            FieldInfo SqlMapper.IMemberMap.Field
            {
                get { return null; }
            }
            Type SqlMapper.IMemberMap.MemberType
            {
                get { return _property.PropertyType; }
            }
            ParameterInfo SqlMapper.IMemberMap.Parameter
            {
                get { return null; }
            }
            PropertyInfo SqlMapper.IMemberMap.Property
            {
                get { return _property; }
            }
        }
    }
