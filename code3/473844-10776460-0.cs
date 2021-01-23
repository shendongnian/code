       private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
           string newSortDirection = String.Empty;
    
       switch (sortDirection)
       {
          case SortDirection.Ascending:
                 newSortDirection = "ASC";
                 break;
    
          case SortDirection.Descending:
             newSortDirection = "DESC";
             break;
       }
    
       return newSortDirection;
    }
        
    protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
    {
       DataTable dataTable = gridView.DataSource as DataTable;
    
       if (dataTable != null)
       {
          DataView dataView = new DataView(dataTable);
          dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
    
          gridView.DataSource = dataView;
          gridView.DataBind();
       }
    }
