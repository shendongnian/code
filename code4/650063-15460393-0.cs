    private T GetObject<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                string columnname = "";
                PropertyInfo[] Properties = typeof(T).GetProperties();
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        var value = row[columnname];
                        if (!string.IsNullOrEmpty(value.ToString()))
                        {
                            Type type;
                            type = Nullable.GetUnderlyingType(objProperty.PropertyType) ?? objProperty.PropertyType;
                            objProperty.SetValue(obj,
                                                 type == value.GetType()
                                                     ? Convert.ChangeType(value, type)
                                                     : System.Enum.ToObject(type, value), null);
                        }
                    }
                }
                return obj;
            }
            catch (Exception exception)
            {
                return obj;
            }
        }
