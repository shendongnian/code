        using System;
        using System.Diagnostics;
        using System.Windows.Forms;
        using Microsoft.Vbe.Interop;
        using ExcelInterop = Microsoft.Office.Interop.Excel;
        namespace WindowsFormsApplication1
        {
            public partial class AddExcelMacro : Form
            {
                public AddExcelMacro()
                {
                    InitializeComponent();
                    AddMacro();
                }
                public void AddMacro()
                {
                    try
                    {
                        // open excel file 
                        const string excelFile = @"c:\temp\VBA\test.xlsm";
                        var excelApplication = new ExcelInterop.Application { Visible = true };
                        var targetExcelFile = excelApplication.Workbooks.Open(excelFile);
                        // add standart module to file
                        var newStandardModule = targetExcelFile.VBProject.VBComponents.Add(vbext_ComponentType.vbext_ct_StdModule);
                        var codeModule = newStandardModule.CodeModule;
                        // add vba code to module
                        var lineNum = codeModule.CountOfLines + 1;
                        var macroName = "Button1_Click";
                        var codeText = "Public Sub " + macroName +"()" + "\r\n";
                        codeText += "  MsgBox \"Hi from Excel\"" + "\r\n";
                        codeText += "End Sub";
                        codeModule.InsertLines(lineNum, codeText);
                        targetExcelFile.Save();
                        // run the macro
                        var macro = string.Format("{0}!{1}.{2}", targetExcelFile.Name, newStandardModule.Name, macroName);
                        excelApplication.Run(macro);
                        
                        excelApplication.Quit();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        throw;
                    }
                }
            }
        }
