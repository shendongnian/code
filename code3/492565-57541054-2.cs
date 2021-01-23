    public static List<T> ToList<T>(this DataTable table) where T : class, new()
    {
        try
        {
            List<T> list = new List<T>();
            foreach (var row in table.AsEnumerable())
            {
                T obj = new T();
                foreach (var prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        //Set the column name to be the name of the property
                        string ColumnName = prop.Name;
                        //Get a list of all of the attributes on the property
                        object[] attrs = prop.GetCustomAttributes(true);
                        foreach (object attr in attrs)
                        {
                            //Check if there is a custom property name
                            if (attr is MySqlColName colName)
                            {
                                //If the custom column name is specified overwrite property name
                                if (!colName.Name.IsNullOrWhiteSpace())                                        
                                    ColumnName = colName.Name;
                            }
                        }
                        PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                        
                        //GET THE COLUMN NAME OFF THE ATTRIBUTE OR THE NAME OF THE PROPERTY
                        propertyInfo.SetValue(obj, Convert.ChangeType(row[ColumnName], propertyInfo.PropertyType), null);
                    }
                    catch
                    {
                        continue;
                    }
                }
                list.Add(obj);
            }
            return list;
        }
        catch
        {
            return null;
        }
    }//END METHOD
