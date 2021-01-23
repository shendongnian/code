    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dd = (DropDownList)sender;
        // you can get dropdown from table row over here.
        // process with it as per your requirement.
        string strdropdownID = ((System.Web.UI.Control)(dd)).ID;
        string id = strdropdownID.Split('_')[1].ToString();
        string tblcID = "celula_" + id.ToString();
        TableCell celula = (TableCell)tabel.FindControl(tblcID);
        celula.RowSpan = Convert.ToInt32(dd.SelectedValue);
    }
