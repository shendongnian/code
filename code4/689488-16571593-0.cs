        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Reflection;
    
    namespace xxxx.Sql.Extensions
    {
        public static class DataTableExtensions
        {
            /// <summary>
            /// Gets a list of objects  based on a generic datatable
            /// </summary>
            /// <typeparam name="T">List of objects</typeparam>
            /// <param name="table">Existing datatable</param>
            /// <returns></returns>
            public static IList<T> ToList<T>(this DataTable table) where T : new()
            {
                IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
                IList<T> result = new List<T>();
    
                foreach (var row in table.Rows)
                {
                    var item = CreateItemFromRow<T>((DataRow)row, properties);
                    result.Add(item);
                }
    
                return result;
            }
    
            private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
            {
                T item = new T();
    
                foreach (var property in properties)
                {
                    if (row.Table.Columns.Contains(property.Name))
                    {
                        var prop = row[property.Name] == System.DBNull.Value ? null : row[property.Name];
                        property.SetValue(item, prop, null);
                    }
                }
                return item;
            }
            /// <summary>
            /// Creat a generic string list on the first field of a dataTable
            /// </summary>
            /// <param name="table"></param>
            /// <returns></returns>
            public static List<string> ToStringList(this DataTable table)
            {
                List<string> result = new List<string>();
    
                foreach (DataRow dr in table.Rows)
                    result.Add(dr[0].ToString());
    
                return result;
            }
        }
    }
