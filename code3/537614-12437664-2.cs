            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            using System.Data;
            using System.ComponentModel;
            using System.Reflection;
            namespace Common
            {
                public static class DataTableExtensions
                {
                    public static DataTable ConvertToDataTable<T>(this IList<T> data)
                    {
                        PropertyDescriptorCollection properties =
                            TypeDescriptor.GetProperties(typeof(T));
                        DataTable table = new DataTable();
                        foreach (PropertyDescriptor prop in properties)
                            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                        foreach (T item in data)
                        {
                            DataRow row = table.NewRow();
                            foreach (PropertyDescriptor prop in properties)
                                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                            table.Rows.Add(row);
                        }
                        table.AcceptChanges();
                        return table;
                    }
                    public static DataRow ConvertToDataRow<T>(this T item, DataTable table)
                    {
                        PropertyDescriptorCollection properties =
                            TypeDescriptor.GetProperties(typeof(T));
                        DataRow row = table.NewRow();
                        foreach (PropertyDescriptor prop in properties)
                            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        return row;
                    }
                    public static T ConvertToEntity<T>(this DataRow tableRow) where T : new()
                    {
                        // Create a new type of the entity I want
                        Type t = typeof(T);
                        T returnObject = new T();
                        foreach (DataColumn col in tableRow.Table.Columns)
                        {
                            string colName = col.ColumnName;
                            // Look for the object's property with the columns name, ignore case
                            PropertyInfo pInfo = t.GetProperty(colName.ToLower(),
                                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                            // did we find the property ?
                            if (pInfo != null)
                            {
                                object val = tableRow[colName];
                                // is this a Nullable<> type
                                bool IsNullable = (Nullable.GetUnderlyingType(pInfo.PropertyType) != null);
                                if (IsNullable)
                                {
                                    if (val is System.DBNull)
                                    {
                                        val = null;
                                    }
                                    else
                                    {
                                        // Convert the db type into the T we have in our Nullable<T> type
                                        val = Convert.ChangeType(val, Nullable.GetUnderlyingType(pInfo.PropertyType));
                                    }
                                }
                                else
                                {
                                    // Convert the db type into the type of the property in our entity
                                    SetDefaultValue(ref val, pInfo.PropertyType);
                                    if (pInfo.PropertyType.IsEnum && !pInfo.PropertyType.IsGenericType)
                                    {
                                        val = Enum.ToObject(pInfo.PropertyType, val);
                                    }
                                    else
                                        val = Convert.ChangeType(val, pInfo.PropertyType);
                                }
                                // Set the value of the property with the value from the db
                                if (pInfo.CanWrite)
                                    pInfo.SetValue(returnObject, val, null);
                            }
                        }
                        // return the entity object with values
                        return returnObject;
                    }
                    private static void SetDefaultValue(ref object val, Type propertyType)
                    {
                        if (val is DBNull)
                        {
                            val = GetDefault(propertyType);
                        }
                    }
                    public static object GetDefault(Type type)
                    {
                        if (type.IsValueType)
                        {
                            return Activator.CreateInstance(type);
                        }
                        return null;
                    }
                    public static List<T> ConvertToList<T>(this DataTable table) where T : new()
                    {
                        Type t = typeof(T);
                        // Create a list of the entities we want to return
                        List<T> returnObject = new List<T>();
                        // Iterate through the DataTable's rows
                        foreach (DataRow dr in table.Rows)
                        {
                            // Convert each row into an entity object and add to the list
                            T newRow = dr.ConvertToEntity<T>();
                            returnObject.Add(newRow);
                        }
                        // Return the finished list
                        return returnObject;
                    }
                }
            }
