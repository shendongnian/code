    public void RefreshSheets(Excel.Workbook WB)
        {
            WB.RefreshAll();
            ExcelApp.Application.CalculateUntilAsyncQueriesDone(); // This condition will wait till background query is completed.
        }
