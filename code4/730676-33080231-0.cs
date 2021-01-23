    /*
    * ----------------------------------------------------------------------------
    * "THE BEER-WARE LICENSE" (Revision 42):
    * <fg@code-works.de> wrote this file. As long as you retain this notice you
    * can do whatever you want with this stuff. If we meet some day, and you think
    * this stuff is worth it, you can buy me a beer in return. Frank Gehann
    * ----------------------------------------------------------------------------
    */
    
    using System;
    using System.Text;
    using System.Data;
    using MySql.Data.MySqlClient;
    
    namespace DB
    {
        class DBHelper
        {
            /// <summary>
            /// Creates a multivalue insert for MySQL from a given DataTable
            /// </summary>
            /// <param name="table">reference to the Datatable we're building our String on</param>
            /// <param name="table_name">name of the table the insert is created for</param>
            /// <returns>Multivalue insert String</returns>
            public static String BulkInsert(ref DataTable table, String table_name)
            {
                try
                {
                    StringBuilder queryBuilder = new StringBuilder();
                    DateTime dt;
    
                    queryBuilder.AppendFormat("INSERT INTO `{0}` (", table_name);
    
                    // more than 1 column required and 1 or more rows
                    if (table.Columns.Count > 1 && table.Rows.Count > 0)
                    {
                        // build all columns
                        queryBuilder.AppendFormat("`{0}`", table.Columns[0].ColumnName);
    
                        if (table.Columns.Count > 1)
                        {
                            for (int i = 1; i < table.Columns.Count; i++)
                            {
                                queryBuilder.AppendFormat(", `{0}` ", table.Columns[i].ColumnName);
                            }
                        }
    
                        queryBuilder.AppendFormat(") VALUES (", table_name);
    
                        // build all values for the first row
                        // escape String & Datetime values!
                        if (table.Columns[0].DataType == typeof(String))
                        {
                            queryBuilder.AppendFormat("'{0}'", MySqlHelper.EscapeString(table.Rows[0][table.Columns[0].ColumnName].ToString()));
                        }
                        else if (table.Columns[0].DataType == typeof(DateTime))
                        {
                            dt = (DateTime)table.Rows[0][table.Columns[0].ColumnName];
                            queryBuilder.AppendFormat("'{0}'", dt.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else if (table.Columns[0].DataType == typeof(Int32))
                        {
                            queryBuilder.AppendFormat("{0}", table.Rows[0].Field<Int32?>(table.Columns[0].ColumnName) ?? 0);
                        }
                        else
                        {
                            queryBuilder.AppendFormat(", {0}", table.Rows[0][table.Columns[0].ColumnName].ToString());
                        }
    
                        for (int i = 1; i < table.Columns.Count; i++)
                        {
                            // escape String & Datetime values!
                            if (table.Columns[i].DataType == typeof(String))
                            {
                                queryBuilder.AppendFormat(", '{0}'", MySqlHelper.EscapeString(table.Rows[0][table.Columns[i].ColumnName].ToString()));
                            }
                            else if (table.Columns[i].DataType == typeof(DateTime))
                            {
                                dt = (DateTime)table.Rows[0][table.Columns[i].ColumnName];
                                queryBuilder.AppendFormat(", '{0}'", dt.ToString("yyyy-MM-dd HH:mm:ss"));
    
                            }
                            else if (table.Columns[i].DataType == typeof(Int32))
                            {
                                queryBuilder.AppendFormat(", {0}", table.Rows[0].Field<Int32?>(table.Columns[i].ColumnName) ?? 0);
                            }
                            else
                            {
                                queryBuilder.AppendFormat(", {0}", table.Rows[0][table.Columns[i].ColumnName].ToString());
                            }
                        }
    
                        queryBuilder.Append(")");
                        queryBuilder.AppendLine();
    
                        // build all values all remaining rows
                        if (table.Rows.Count > 1)
                        {
                            // iterate over the rows
                            for (int row = 1; row < table.Rows.Count; row++)
                            {
                                // open value block
                                queryBuilder.Append(", (");
    
                                // escape String & Datetime values!
                                if (table.Columns[0].DataType == typeof(String))
                                {
                                    queryBuilder.AppendFormat("'{0}'", MySqlHelper.EscapeString(table.Rows[row][table.Columns[0].ColumnName].ToString()));
                                }
                                else if (table.Columns[0].DataType == typeof(DateTime))
                                {
                                    dt = (DateTime)table.Rows[row][table.Columns[0].ColumnName];
                                    queryBuilder.AppendFormat("'{0}'", dt.ToString("yyyy-MM-dd HH:mm:ss"));
                                }
                                else if (table.Columns[0].DataType == typeof(Int32))
                                {
                                    queryBuilder.AppendFormat("{0}", table.Rows[row].Field<Int32?>(table.Columns[0].ColumnName) ?? 0);
                                }
                                else
                                {
                                    queryBuilder.AppendFormat(", {0}", table.Rows[row][table.Columns[0].ColumnName].ToString());
                                }
    
                                for (int col = 1; col < table.Columns.Count; col++)
                                {
                                    // escape String & Datetime values!
                                    if (table.Columns[col].DataType == typeof(String))
                                    {
                                        queryBuilder.AppendFormat(", '{0}'", MySqlHelper.EscapeString(table.Rows[row][table.Columns[col].ColumnName].ToString()));
                                    }
                                    else if (table.Columns[col].DataType == typeof(DateTime))
                                    {
                                        dt = (DateTime)table.Rows[row][table.Columns[col].ColumnName];
                                        queryBuilder.AppendFormat(", '{0}'", dt.ToString("yyyy-MM-dd HH:mm:ss"));
                                    }
                                    else if (table.Columns[col].DataType == typeof(Int32))
                                    {
                                        queryBuilder.AppendFormat(", {0}", table.Rows[row].Field<Int32?>(table.Columns[col].ColumnName) ?? 0);
                                    }
                                    else
                                    {
                                        queryBuilder.AppendFormat(", {0}", table.Rows[row][table.Columns[col].ColumnName].ToString());
                                    }
                                } // end for (int i = 1; i < table.Columns.Count; i++)
    
                                // close value block
                                queryBuilder.Append(")");
                                queryBuilder.AppendLine();
    
                            } // end for (int r = 1; r < table.Rows.Count; r++)
    
                            // sql delimiter =)
                            queryBuilder.Append(";");
    
                        } // end if (table.Rows.Count > 1)
    
                        return queryBuilder.ToString();
                    } 
                    else
                    {
                        return "";
                    } // end if(table.Columns.Count > 1 && table.Rows.Count > 0)
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
