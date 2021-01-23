    private void SortGridView(string sortExpression, string direction)
    {
        //  You can cache the DataTable for improving performance
        gwreportpub.DataSource = getDatiFromDb().Tables[0];
        gwreportpub.DataBind();
        if(ViewState["sortExpr"] != null){
          DataTable dt = gwreportpub.DataSource as DataTable;
          DataView dv = new DataView(dt);
          dv.Sort = (string)ViewState["sortExpr"];
        }
        gwreportpub.DataSource = dv;
        gwreportpub.DataBind();
    
    }
