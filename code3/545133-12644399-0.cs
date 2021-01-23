    using System;
    using System.Collections.Generic;
    using System.Data;
    using Newtonsoft.Json;
    class Program
    {
        static void Main(string[] args)
        {
            var dataSet = new DataSet();
            var dataTable = new DataTable();
            for (int i = 0; i < 5; i++) { dataTable.Columns.Add(string.Format("Column{0}", i), typeof(string)); }
            for (int i = 0; i < 5; i++)
            {
                var vals = new List<object>();
                for (int j = 0; j < 5; j++) { vals.Add(string.Format("Value {0}", j)); }
                dataTable.LoadDataRow(vals.ToArray(), true);
            }
            dataSet.Tables.Add(dataTable);
            dataSet.AcceptChanges();
            Console.WriteLine(JsonConvert.SerializeObject(dataSet));
        }
    }
