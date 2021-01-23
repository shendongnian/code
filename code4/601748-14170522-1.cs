      using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Get the DataTable.
                DataTable table = GetTable();
    
                //get new data table 
                DataTable newTable = GetNewTable();
    
                for (int i = table.Rows.Count - 1; i > -1; i--)
                {
                    var gTotalIndex = (table.Rows.Count - i) - 1;
                    newTable.Rows.Add(i,null,null, table.Rows[gTotalIndex]["Category"], table.Rows[gTotalIndex]["Name"], table.Rows[gTotalIndex]["PROJID"], table.Rows[gTotalIndex]["Type"], table.Rows[gTotalIndex]["Amt"]);
                }
    
                var oTotal = 0;
                for (int i = newTable.Rows.Count - 1; i > -1; i--)
                {
                    if (newTable.Rows[i]["Category"].ToString() == "GRAND_TOTAL")
                        continue;
                    if (newTable.Rows[i]["Category"].ToString() == "OVERALL_TOTAL")
                    {
                        oTotal = 0;
                        newTable.Rows[i]["O_T_I"] = oTotal;
                        oTotal++;
                    }
                    else
                    {
                        newTable.Rows[i]["O_T_I"] = oTotal;
                        oTotal++;
                    }
                }
    
                var pTotal = 0;
                for (int i = newTable.Rows.Count - 1; i > -1; i--)
                {
                    if (newTable.Rows[i]["Category"].ToString() == "GRAND_TOTAL" || newTable.Rows[i]["Category"].ToString() == "OVERALL_TOTAL")
                        continue;
                    if (newTable.Rows[i]["Category"].ToString() == "PROJ_TOTAL")
                    {
                        pTotal = 0;
                        newTable.Rows[i]["P_T_I"] = pTotal;
                        pTotal++;
                    }
                    else
                    {
                        newTable.Rows[i]["P_T_I"] = pTotal;
                        pTotal++;
                    }
                }
    
            }
    
            static DataTable GetNewTable()
            {
                DataTable table = new DataTable();
                table.Columns.Add("G_T_I", typeof(int));
                table.Columns.Add("O_T_I", typeof(int));
                table.Columns.Add("P_T_I", typeof(int));
                table.Columns.Add("Category", typeof(string));
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("PROJID", typeof(string));
                table.Columns.Add("Type", typeof(string));
                table.Columns.Add("Amt", typeof(decimal));
                return table;
            }
    
            static DataTable GetTable()
            {
                DataTable table = new DataTable();
                table.Columns.Add("Category", typeof(string));
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("PROJID", typeof(string));
                table.Columns.Add("Type", typeof(string));
                table.Columns.Add("Amt", typeof(decimal));
    
                table.Rows.Add("NEW_PROJ", "ABC", "100", "Acost", 10);
                table.Rows.Add("SAME_PROJ", "", "", "Bcost", 20);
                table.Rows.Add("PROJ_TOTAL", "", "100 Total", "", 30);
                table.Rows.Add("NEW_PROJ", "", "200", "Acost", 40);
                table.Rows.Add("PROJ_TOTAL", "", "200 Total", "", 40);
                table.Rows.Add("OVERALL_TOTAL", "ABC Total", "", "", 70);
                table.Rows.Add("NEW_PROJ", "PQR", "300", "Acost", 10);
                table.Rows.Add("SAME_PROJ", "", "", "Bcost", 10);
                table.Rows.Add("PROJ_TOTAL", "", "300 Total", "", 20);
                table.Rows.Add("OVERALL_TOTAL", "PQR Total", "", "", 20);
                table.Rows.Add("GRAND_TOTAL", "", "", "", 90);
    
                return table;
            }
        }
    }
