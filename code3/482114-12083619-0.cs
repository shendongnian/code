    public void AddControl(string strCntrlName)
    {
        Microsoft.Office.Interop.Excel.Worksheet nativeWorksheet = Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet;
        Microsoft.Office.Tools.Excel.Worksheet vstoWorksheet = Globals.Factory.GetVstoObject(nativeWorksheet);
        var btn = new System.Windows.Forms.Button();
        btn.Name = "Button1";
        btn.Text = "Click Me";
        btn.Click += new EventHandler(btn_Click);
        vstoWorksheet.Controls.AddControl(btn, nativeWorksheet.Range["A1", "E5"], strCntrlName);
    }
    void btn_Click(object sender, EventArgs e)
    {
                        
    }
