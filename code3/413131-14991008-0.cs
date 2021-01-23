        public void GridView_ExampleSorting(object sender, GridViewSortEventArgs e)
        {
            GridView gv = (GridView)sender;
            DataTable dataTable = gv.DataSource as DataTable;
            if (dataTable != null)
            {
                string sortdirection = GetNextSortDirection(e.SortExpression); 
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + sortdirection;
                if (e.SortExpression.ToString() == "priority")
                    dataView.Sort += " date DESC";
                gv.DataSource = dataView;
                gv.PageIndex = 0; 
                gv.DataBind();
            }
        }
