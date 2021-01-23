    private static void buttonMacro(string buttonName, Excel.Application xlApp, Excel.Workbook wrkBook, Excel.Worksheet wrkSheet)
    {
        StringBuilder sb;
        VBIDE.VBComponent xlModule;
        VBIDE.VBProject prj;
        prj = wrkBook.VBProject;
        sb = new StringBuilder();
        // build string with module code
        sb.Append("Sub " + buttonName + "_Click()" + "\n");
        sb.Append("\t" + "msgbox \"" + buttonName + "\"\n"); // add your custom vba code here
        sb.Append("End Sub");
        // set an object for the new module to create
        xlModule = wrkBook.VBProject.VBComponents.Add(VBIDE.vbext_ComponentType.vbext_ct_StdModule);
        // add the macro to the spreadsheet
        xlModule.CodeModule.AddFromString(sb.ToString());
    }
