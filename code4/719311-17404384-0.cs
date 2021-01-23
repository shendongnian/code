        private void Button1_Click(object sender, EventArgs e)
        {
            CrystalReport1 report1 = new CrystalReport1();
            PrintDialog dialog1 = new PrintDialog();
            report1.SetDatabaseLogon("username", "password");
            dialog1.AllowSomePages = true;
            dialog1.AllowPrintToFile = false;
            dialog1.PrintToFile = false;
            if (dialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int copies = dialog1.PrinterSettings.Copies;
                int fromPage = dialog1.PrinterSettings.FromPage;
                int toPage = dialog1.PrinterSettings.ToPage;
                bool collate = dialog1.PrinterSettings.Collate;
                
                report1.PrintOptions.PrinterName = dialog1.PrinterSettings.PrinterName;
                report1.PrintToPrinter(copies, collate, fromPage, toPage);            
            }
            report1.Dispose();
            dialog1.Dispose();
        }
