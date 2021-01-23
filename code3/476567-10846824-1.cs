    protected void GridView_Users_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (String.IsNullOrEmpty(ViewState["sortExpression"].ToString()) && String.IsNullOrEmpty(ViewState["sortDirection"].ToString()))
        {
          //Sort and bind data as ASCENDING for the first time
          DefaultSortBind(e);
        }
        else
        {
            if (ViewState["sortExpression"].ToString() == e.SortExpression.ToString())
            {
                string sortDirection = string.Empty;
                if (ViewState["sortDirection"].ToString() == e.SortDirection.ToString())
                {
                    sortDirection = flipSortDirection(GetSortDirection(e.SortDirection.ToString()));
                }
                else
                {
                    sortDirection = GetSortDirection(e.SortDirection.ToString());
                }
                DataTable dt = new UserInfoTableTableAdapter().GetData();
                dt.DefaultView.Sort = e.SortExpression + " " + sortDirection;
                GridView_Users.DataSource = dt.DefaultView;
                GridView_Users.DataBind();
                ViewState["sortedDt"] = dt.DefaultView.ToTable();
                ViewState["sortDirection"] = sortDirection;
            }
            else
            {
                //Sort and bind data as ASCENDING
                DefaultSortBind(e);
            }
        }
    }
        private void DefaultSortBind(GridViewSortEventArgs e)
    {
        ViewState["sortExpression"] = e.SortExpression;
        ViewState["sortDirection"] = e.SortDirection;
        //Fetch data again, because if we try to get data from gridview it will give null
        DataTable dt = new UserInfoTableTableAdapter().GetData();
        dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortDirection.ToString());
        GridView_Users.DataSource = dt.DefaultView;
        GridView_Users.DataBind();
        ViewState["sortedDt"] = dt.DefaultView.ToTable();
    }
        //Get sort direction
    private string GetSortDirection(string sortDirection)
    {
        if (sortDirection == "Ascending")
        {
            return "ASC";
        }
        else
        {
            return "DESC";
        }
    }
    //Flip sort direction
    private string flipSortDirection(string sortDirection)
    {
        if (sortDirection == "ASC")
        {
            return "DESC";
        }
        else
        {
            return "ASC";
        }
    }
