    String updateBT "...// macro code for button";   
    VBA.VBComponent oModule1 = xlWorkBook.VBProject.VBComponents.Add(VBA.vbext_ComponentType.vbext_ct_StdModule);
    oModule1.Name = "Update";
    oModule1.CodeModule.AddFromString(updateBT);
    Excel.Shape btn2 = xlWorkSheet1.Shapes.AddFormControl(Excel.XlFormControl.xlButtonControl, 150, 5, 150, 22);
    btn2.Name = "Update";
    btn2.OnAction = "... // name of your macro code";
    btn2.OLEFormat.Object.Caption = "... // Button name";
