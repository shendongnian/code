    using Excel = Microsoft.Office.Interop.Excel;
                       :
                       :
    Excel.ControlFormat Scrollbar  = oSheet.Shapes.AddFormControl(Excel.XlFormControl.xlScrollBar, 545, 172, 398, 24).ControlFormat;
    Scrollbar.Value = 0;
    Scrollbar.Min = 0;
    Scrollbar.Max=100;
    Scrollbar.SmallChange = 1;
    Scrollbar.LargeChange = 10;
    Scrollbar.LinkedCell = "$A$1";
