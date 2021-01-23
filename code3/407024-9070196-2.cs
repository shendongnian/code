      using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.IO;
    using System.Windows.Forms;
    
    namespace xmlCustomReformat
    {
        public static class ExportDataTable
        {
           public static void Write(DataTable dt, string filePath)
            {
                int i = 0;
                StreamWriter sw = null;
    
                try
                {
    
                    sw = new StreamWriter(filePath + "\\Acord_Combined.txt", false);
    
                    for (i = 0; i < dt.Columns.Count-1; i++)
                    {
    
                        sw.Write(String.Format("{0,-50}",dt.Columns[i].ColumnName));
    
                    }
                    sw.Write(dt.Columns[i].ColumnName);
                    sw.WriteLine();
    
                    foreach (DataRow row in dt.Rows)
                    {
                        object[] array = row.ItemArray;
    
                        for (i = 0; i < array.Length - 1; i++)
                        {
                            sw.Write(String.Format("{0,-50}",array[i].ToString()));
                        }
                        sw.Write(array[i].ToString());
                        sw.WriteLine();
    
                    }
    
                    sw.Close();
                }
    
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Operation : \n" + ex.ToString(),
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
     }
