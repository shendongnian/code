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
    
            protected void RadgvData_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
            {
                try
                {
                    DataTable dtData = objCutTypeBAL.getCutTypeDetail(string.Empty);
                    if (dtData.Rows.Count > 0)
                    {
                        RadgvData.DataSource = dtData;
                    }
                    else
                    {
                        RadgvData.DataSource = String.Empty;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            protected void RadgvData_ItemDataBound(object sender, GridItemEventArgs e)
            {
                if (e.Item is GridPagerItem)
                {
                    RadgvData.PagerStyle.AlwaysVisible = true;
                }
                if (e.Item is GridDataItem && e.Item.OwnerTableView.DataMember != "ChildCutType")
                {
                    GridDataItem dataitem = (GridDataItem)e.Item;
    
                    ImageButton imgDel = (ImageButton)dataitem["Delete"].Controls[0];
                    string strCutType;
                    strCutType = dataitem.GetDataKeyValue("CutType").ToString();
                    DataTable dtData = objCutTypeBAL.getCutTypeDetail(strCutType);
                    if (dtData.Rows.Count > 0)
                    {
                        imgDel.Visible = false;
                    }
                }
            }
    
            protected void RadgvData_PageIndexChanged(object sender, GridPageChangedEventArgs e)
            {
                RadgvData.CurrentPageIndex = e.NewPageIndex;
                popGrid();
            }
