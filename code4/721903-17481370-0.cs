    protected void GridView_PreRender(object sender, EventArgs e)
        {
            if(Reqest.QueryString["Id"]="all"&& Reqest.QueryString["Id"]!=null)
             {
               GridViewId.Columns[1].Visible = true;
             }
            else
                GridViewId.Columns[1].Visible = false;
        }
