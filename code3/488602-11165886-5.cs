       public static void TurnOffApplicationSettings(Excel.Application xlApp)
            {
                xlApp.ScreenUpdating = false;
                xlApp.DisplayAlerts = false;
                xlApp.Calculation = XlCalculation.xlCalculationManual;
                xlApp.UserControl = false;
                xlApp.EnableEvents = false;
            }
    
            public static void TurnOnApplicationSettings(Excel.Application xlApp)
            {
                xlApp.ScreenUpdating = true;
                xlApp.DisplayAlerts = true;
                xlApp.Calculation = XlCalculation.xlCalculationAutomatic;
                xlApp.UserControl = true;
                xlApp.EnableEvents = true;
            }
