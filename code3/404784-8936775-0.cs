    // Start excel
    Microsoft.Office.Interop.Excel.Application oXL = new Microsoft.Office.Interop.Excel.Application();
    oXL.Visible = true;
    
    // Get a sheet 
    Microsoft.Office.Interop.Excel._Workbook oWB = (Microsoft.Office.Interop.Excel._Workbook)oXL.Workbooks.Add(System.Reflection.Missing.Value);
    Microsoft.Office.Interop.Excel._Worksheet oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;
    
    // Get ole objects and add new one
    Microsoft.Office.Interop.Excel.OLEObjects objs = oSheet.OLEObjects();
    
    // Here is the method that is posted in the answer
    Microsoft.Office.Interop.Excel.OLEObject obj = objs.Add("Forms.CheckBox.1", 
        System.Reflection.Missing.Value,
        System.Reflection.Missing.Value,
        false,
        false,
        System.Reflection.Missing.Value,
        System.Reflection.Missing.Value,
        65.25,
        24,
        108,
        21);
    // Here, you are making it checked. obj.Object is dynamic, so you will not get help from visual studio, but you know what properties CheckBox can have, right?
    obj.Object.Value = true;
