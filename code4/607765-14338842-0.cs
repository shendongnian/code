    using System.Collections.Generic;
    using Excel = Microsoft.Office.Interop.Excel;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var bankAccounts = new List<Account> {
                    new Account { ID = 345678, Balance = 541.27},
                    new Account {ID = 1230221,Balance = -1237.44},
                    new Account {ID = 346777,Balance = 3532574},
                    new Account {ID = 235788,Balance = 1500.033333}
    };
                DisplayInExcel(bankAccounts);
            }
            static void DisplayInExcel(IEnumerable<Account> accounts)
            {
                var excelApp = new Excel.Application { Visible = true };
                excelApp.Workbooks.Add();
                Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;
                workSheet.Cells[1, "A"] = "ID Number";
                workSheet.Cells[1, "B"] = "Current Balance";
                var row = 1;
                foreach (var acct in accounts)
                {
                    row++;
                    workSheet.Cells[row, "A"] = acct.ID;
                    workSheet.Cells[row, "B"] = acct.Balance;
    
                }
                workSheet.Range["B2", "B" + row].NumberFormat = "#,###.00 €";
                workSheet.Columns[1].AutoFit();
                workSheet.Columns[2].AutoFit();
            }
        }
        public class Account
        {
            public int ID { get; set; }
            public double Balance { get; set; }
        }
    }
