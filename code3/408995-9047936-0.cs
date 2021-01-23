    private void AddCheckBox()
    {
        Worksheet vstoWorksheet = Globals.Factory.GetVstoObject(
            this.Application.ActiveWorkbook.Worksheets[1]);
        System.Windows.Forms.CheckBox checkbox = 
    	    new System.Windows.Forms.CheckBox();
    	checkbox.Checked = true;
    	checkbox.Text = "xyz"	
        vstoWorksheet.Controls.AddControl(234, 234, 108, 21, "checkbox1");
    }
