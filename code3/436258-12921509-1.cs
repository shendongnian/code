    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    using System.IO;
    
    public void Build(DataSet ds) 
    {
        StringWriter sw = new StringWriter();
        HtmlTextWriter w = new HtmlTextWriter(sw);
        foreach (DataTable dt in ds.Tables) 
        {
            //Create a table
            Table tbl = new Table();
    
            //Create column header row
            TableHeaderRow thr = new TableHeaderRow();
            foreach (DataColumn col in dt.Columns) {
                TableHeaderCell th = new TableHeaderCell();
                th.Text = col.Caption;
                thr.Controls.Add(th);
            }
            tbl.Controls.Add(thr);
    
            //Create table rows
            foreach (DataRow row in dt.Rows)
            {
                TableRow tr = new TableRow();
                foreach (var value in row.ItemArray)
                {
                    TableCell td= new TableCell();
                    td.Text = value.ToString();
                    tr.Controls.Add(td);
                }
                tbl.Controls.Add(tr);
            }
            tbl.RenderControl(w);
    
        }
    
        Response.Write(sw.ToString());
    }
 
