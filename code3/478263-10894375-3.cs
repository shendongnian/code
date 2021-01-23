    protected void GridView1_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
    {
        string currentSortColumn = null;
        string currentSortDirection = null;
        currentSortColumn = this.SortExpression.Split(' ')[0];
        currentSortDirection = this.SortExpression.Split(' ')[1];
        if (e.SortExpression.Equals(currentSortColumn))
        {
            //switch sort direction
            switch (currentSortDirection.ToUpper())
            {
                case "ASC":
                    this.SortExpression = currentSortColumn + " DESC";
                    break;
                case "DESC":
                    this.SortExpression = currentSortColumn + " ASC";
                    break;
            }
        }
        else
        {
            this.SortExpression = e.SortExpression + " ASC";
        }
        BindGrid();
    }
