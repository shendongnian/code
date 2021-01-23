    namespace ConsoleApplication1
    {
        using System;
        using System.Collections.Generic;
        using System.Data;
        using System.Diagnostics;
        using System.Linq;
        using System.Reflection;
        #region Fake Database
        internal class DatabaseMock
        {
            private DatabaseMock() { 
                // Hides the default public constructor created by the compiler
                // Uses the factory pattern for creation instead
            }
            /// <summary>
            /// Creates a new instance of a database with three default items
            /// </summary>
            public static DatabaseMock Create() {
                DatabaseMock database = new DatabaseMock();
                List<ItemMock> items = new List<ItemMock>();
                items.Add(new ItemMock("item1"));
                items.Add(new ItemMock("item2"));
                items.Add(new ItemMock("item3"));
                database.Table = items;
                return database;
            }
            /// <summary>
            /// Gets the items in the database
            /// </summary>
            public IEnumerable<ItemMock> Table {
                get;
                private set;
            }
        }
        internal struct ItemMock
        {
            /// <summary>
            /// Initializes a new instance of the ItemMock class
            /// </summary>
            public ItemMock(string value) {
                _value = value;
            }
            private string _value;
            /// <summary>
            /// Gets the items value
            /// </summary>
            public string Value {
                get {
                    return _value;
                }
            }
        }
        #endregion
        static class Program
        {
            /// <summary>
            /// Takes the specified DataTable and anonymous type information, and populates the table with a new DataColumn per anonymous type property
            /// </summary>
            public static void FillColumns(DataTable table, Type anonymousType) {
                PropertyInfo[] properties = anonymousType.GetProperties();
                foreach (PropertyInfo property in properties) {
                    table.Columns.Add(property.Name);
                }
            }
            static void Main() {
                DatabaseMock database = DatabaseMock.Create();
                var query =
                    from item in database.Table
                    select new {
                        field1 = item.Value,
                        field2 = item.Value,
                        field3 = item.Value
                    };
                if (query.Count() != 0) {
                    DataTable table = new DataTable("Table");
                    FillColumns(table, query.First().GetType());
    #if DEBUG
                    foreach (DataColumn column in table.Columns) {
                        Debug.WriteLine(column.ColumnName);
                    }
    #endif
                }
            }
        }
    }
