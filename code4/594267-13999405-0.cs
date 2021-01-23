    using Excel = Microsoft.Office.Interop.Excel;
    using VB = Microsoft.Vbe.Interop;
    Excel.Application eApp = new Excel.Application();
    
    eApp.Visible = true;
    Excel.Workbook eBook = eApp.Workbooks.Add();
    
    VB.VBProject eVBProj = (VB.VBProject)eBook.VBProject;
    VB._VBComponent vbModule = eVBProj.VBE.ActiveVBProject.VBComponents.Add(VB.vbext_ComponentType.vbext_ct_StdModule);
    
    String functionText = "Function MyTest()\n";
          functionText += "MsgBox \"Hello World\"\n";
          functionText += "End Function";
    
    vbModule.CodeModule.AddFromString(functionText);
