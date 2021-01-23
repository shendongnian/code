		 if (GridSortOrder == ASCENDING)
            {
                var result = from table in Ob.DataTableOther.AsEnumerable()
                             orderby table.Field<string>("CustomerName")
                             select table;
                var dv = result.AsDataView();
                grdReport.DataSource = dv;
                grdReport.DataBind();
                
            }
            else
            {
                var result = from table in Ob.DataTableOther.AsEnumerable()
                             orderby table.Field<string>("CustomerName") descending
                             select table;
                var dv = result.AsDataView();
                grdReport.DataSource = dv;
                grdReport.DataBind();   
            }
             /*
             * logic for remaining columns 
             */
            //Change the sortOrder
            ChangeSortOrder(GridSortOrder);
