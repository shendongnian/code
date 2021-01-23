    protected void GridView1_DataBound(object sender, EventArgs e)
    {
    for (int i = 0; i < GridView1.Rows.Count; i++)
    {
        if (GridView1.Rows[i].Cells[1].Text == "NA")
        {
          Button btnVal= (Button)e.Row.FindControl("buttonSubmit");
          btnVal.Enabled = false;
        }
    }
    }
