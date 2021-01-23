    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Office.Interop.Excel;
    using System.Data;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
            
            System.Data.DataTable xlsData = new System.Data.DataTable();
            string xlsConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=d:\\romil.xlsx;Extended Properties=\"Excel 12.0;HDR=Yes;\"";
            System.Data.OleDb.OleDbConnection xlsCon = new System.Data.OleDb.OleDbConnection(xlsConnectionString);
            System.Data.OleDb.OleDbCommand xlsCommand;
            int recUpdate;
            int recordsinSheet;
            xlsCommand = new System.Data.OleDb.OleDbCommand("Select count(*) as RecCount from [Sheet1$]");
            xlsCommand.Connection = xlsCon;
            xlsCon.Open();
            recordsinSheet =Convert.ToInt32( xlsCommand.ExecuteScalar());
    
            xlsCommand=   new System.Data.OleDb.OleDbCommand("Insert into [Sheet1$] (Field1,Field2) values ('123',2)");
            xlsCommand.Connection = xlsCon;
            
            recUpdate = xlsCommand.ExecuteNonQuery();
            xlsCon.Close();
            if ((recordsinSheet + recUpdate) == 1)
                ChangeFormat();
            Console.ReadKey();
        }
        private static void ChangeFormat()
        {
            string filename = "d:\\romil.xlsx";
            object missing = System.Reflection.Missing.Value ;
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = excel.Workbooks.Open(filename, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Microsoft.Office.Interop.Excel.Worksheet wsh=null;
            foreach (Microsoft.Office.Interop.Excel.Worksheet sheet in wb.Sheets)
            {
                if (sheet.Name == "Sheet1")
                {
                    wsh = sheet;
                    break;
                }
            }
            for (int rCnt = 2; rCnt <= wsh.Rows.Count; rCnt++)
            {
                
                if  ( wsh.Cells[rCnt, 2].Value== null)
                    break;
                wsh.Cells[rCnt, 2] = wsh.Cells[rCnt, 2].Value;
            }    
            wb.SaveAs(filename, missing,
                missing, missing, missing, missing,
               Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                missing, missing, missing,
                missing, missing);
            wb.Close();
        }
    }
}
