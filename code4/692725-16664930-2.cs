    aspx page:
    
    <asp:Table ID="Table1" runat="server">        
    </asp:Table>
    aspx.cs Page:
    
    if (!IsPostBack)
            {
                //Table tbl = new Table();
                TableRow tr = new TableRow();
                TableCell tcel = new TableCell();
                tcel.Text = "id";
                tr.Cells.Add(tcel);
                TableCell tcel1 = new TableCell();
                tcel1.Text = "id1";
                tr.Cells.Add(tcel1);
                Table1.Rows.Add(tr);
            }
    Button Click Event :
    {
      string filename = "ExportExcel.xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                //DataGrid dgGrid = new DataGrid();
                //dgGrid.DataSource = tbl;
                //dgGrid.DataBind();
                //Get the HTML for the control.             
                Table1.RenderControl(hw);
                //Write the HTML back to the browser.
                //Response.ContentType = application/vnd.ms-excel;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
    }
