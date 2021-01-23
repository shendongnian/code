    protected void RadgvData_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            GridTableView tableView = e.Item.OwnerTableView;
            e.Canceled = true;
            GridSortExpression expression = new GridSortExpression();
            expression.FieldName = e.SortExpression;
            if (tableView.SortExpressions.Count == 0 || tableView.SortExpressions[0].FieldName != e.SortExpression)
            {
                expression.SortOrder = GridSortOrder.Descending;
            }
            else if (tableView.SortExpressions[0].SortOrder == GridSortOrder.Descending)
            {
                expression.SortOrder = GridSortOrder.Ascending;
            }
            else if (tableView.SortExpressions[0].SortOrder == GridSortOrder.Ascending)
            {
                expression.SortOrder = GridSortOrder.Descending;
            }
            tableView.SortExpressions.AddSortExpression(expression);
            RadgvData.Rebind();
        }
