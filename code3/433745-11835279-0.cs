    protected void GridView1_RowUpdating(object sender,    
    System.Web.UI.WebControls.GridViewUpdateEventArgs e )
       {
       int row;
       int colidx =1;
       string cellvalue;
       GridViewRow row = Gridview1.rows[e.rowindex]
       cellvalue = row.cells[colidx].text;
       }
