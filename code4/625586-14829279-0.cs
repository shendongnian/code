    class RemoveSpacesMap : Dapper.SqlMapper.ITypeMap
    {
        System.Reflection.ConstructorInfo SqlMapper.ITypeMap.FindConstructor(string[] names, Type[] types)
        {
            return null;
        }
        SqlMapper.IMemberMap SqlMapper.ITypeMap.GetConstructorParameter(System.Reflection.ConstructorInfo constructor, string columnName)
        {
            return null;
        }
        SqlMapper.IMemberMap SqlMapper.ITypeMap.GetMember(string columnName)
        {
            var prop = typeof(ClassA).GetProperty(columnName.Replace(" ", ""));
            return prop == null ? null : new PropertyMemberMap(columnName, prop);
        }
        class PropertyMemberMap : Dapper.SqlMapper.IMemberMap
        {
            private string columnName;
            private PropertyInfo property;
            public PropertyMemberMap(string columnName, PropertyInfo property)
            {
                this.columnName = columnName;
                this.property = property;
            }
            string SqlMapper.IMemberMap.ColumnName
            {
                get { throw new NotImplementedException(); }
            }
            System.Reflection.FieldInfo SqlMapper.IMemberMap.Field
            {
                get { return null; }
            }
            Type SqlMapper.IMemberMap.MemberType
            {
                get { return property.PropertyType; }
            }
            System.Reflection.ParameterInfo SqlMapper.IMemberMap.Parameter
            {
                get { return null; }
            }
            System.Reflection.PropertyInfo SqlMapper.IMemberMap.Property
            {
                get { return property; }
            }
        }
    }
