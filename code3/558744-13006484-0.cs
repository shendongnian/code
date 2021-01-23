    RadioButton rd1 = new RadioButton();
    rd1.Text = "Test1";
    RadioButton rd2 = new RadioButton();
    rd2.Text = "Test2";
    
    HtmlGenericControl br = new HtmlGenericControl("BR");
    
    grdRSM.Rows[0].Cells[2].Controls.Add(rd1);
    grdRSM.Rows[0].Cells[2].Controls.Add(br);
    grdRSM.Rows[0].Cells[2].Controls.Add(rd2);
