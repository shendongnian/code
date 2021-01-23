    DataTable sourceTable = GridAttendence.DataSource as DataTable;
    DataView view = new DataView(sourceTable);
    string[] sortData = Session["sortExpression"].ToString().Trim().Split(' ');
    if (e.SortExpression == sortData[0])
    {
        if (sortData[1] == "ASC")
        {
            view.Sort = e.SortExpression + " " + "DESC";
            this.ViewState["sortExpression"] = e.SortExpression + " " + "DESC";
        }
        else
        {
            view.Sort = e.SortExpression + " " + "ASC";
            this.ViewState["sortExpression"] = e.SortExpression + " " + "ASC";
        }
    }
    else
    {
        view.Sort = e.SortExpression + " " + "ASC";
        this.ViewState["sortExpression"] = e.SortExpression + " " + "ASC";
    }
