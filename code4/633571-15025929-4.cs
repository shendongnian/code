    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.OleDb;
    using System.Data;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            // the Excel file
            string file = @"c:\Temp\Test.xls";
            if (!File.Exists(file))
            {
                Console.WriteLine("File not found.");
                return;
            }
            // DataTable bonus! :)
            System.Data.DataTable dt = new System.Data.DataTable();
            IEnumerable<List<object>> header = new List<List<object>>();
            IEnumerable<List<object>> rows = new List<List<object>>();
            // read the header first
            header = GetData(file, true);
            // read the rows
            rows = GetData(file, false);
            // add the columns
            foreach (var column in header.First())
            {
                dt.Columns.Add(column.ToString());
            }
            // add the rows
            foreach (var row in rows)
            {
                dt.Rows.Add(row.ToArray());
            }
            // now you may use the dt DataTable for your purpose
        }
        /// <summary>
        /// Read from the Excel file
        /// </summary>
        /// <param name="file">The path to the Excel file</param>
        /// <param name="readHeader">True if you want to read the header, 
        /// False if you want to read the rows</param>
        /// <returns></returns>
        private static IEnumerable<List<object>> GetData(string file, bool readHeader)
        {
            string query = "SELECT * FROM [List1$]";
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source=" + file + @";Extended Properties=""Excel 12.0 Xml;HDR=NO;IMEX="
                + ((readHeader) ? "1" : "0") + @";""";
            using (OleDbConnection connection = new OleDbConnection(connString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        bool isHeaderRead = false;
                        while (reader.Read())
                        {
                            if (readHeader && isHeaderRead)
                            { break; }
                            isHeaderRead = true;
                            List<object> values = new List<object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                values.Add(reader.GetValue(i));
                            }
                            yield return values;
                        }
                    }
                }
            }
        }
    }
