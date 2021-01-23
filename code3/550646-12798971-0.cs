    LinkButton btn = (LinkButton)e.Row.FindControl("btn");
    int EmpiD = Int32.Parse(e.Row.Cells[2].Text);
    DataSet EmpIDDs = GetEMP.getValue(EmpiD);
    DataRow EmpRow = EmpIDDs.Tables[0].Rows[0];
    btn.Text = EmpRow[3].ToString();
