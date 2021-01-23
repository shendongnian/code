    using FastMember;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    static class Program
    {
        static void Main()
        {
            var list = GetList();
            var table = ToTable(list);
        }
        static DataTable ToTable(IList source)
        {
            if (source == null) throw new ArgumentNullException();
            var table = new DataTable();
            if (source.Count == 0) return table;
    
            // blatently assume the list is homogeneous
            Type itemType = source[0].GetType();
            table.TableName = itemType.Name;
            List<string> names = new List<string>();
            foreach (var prop in itemType.GetProperties())
            {
                if (prop.CanRead && prop.GetIndexParameters().Length == 0)
                {
                    names.Add(prop.Name);
                    table.Columns.Add(prop.Name, prop.PropertyType);
                }
            }
            names.TrimExcess();
    
            var accessor = TypeAccessor.Create(itemType);
            object[] values = new object[names.Count];
            foreach (var row in source)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = accessor[row, names[i]];
                }
                table.Rows.Add(values);
            }
            return table;
        }
        static IList GetList()
        {
            return new[] {
                new { foo = "abc", bar = 123},
                new { foo = "def", bar = 456},
                new { foo = "ghi", bar = 789},
            };
        }
    }
