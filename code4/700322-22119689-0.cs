            try
            {
                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell td = new HtmlTableCell();
                GridView gv = new GridView();                                
                    gv.AllowPaging = true;
                    gv.PageSize = 20;
                    gv.PagerSettings.Visible = true;
                    gv.PagerSettings.Mode = PagerButtons.NumericFirstLast;
                    gv.PageIndexChanging += new GridViewPageEventHandler(gv_PageIndexChanging);
                
                FillGrid(gv);
                
                td.Controls.Add(gv);
                tr.Cells.Add(td);
                tbl1.Rows.Add(tr);
                
                gv.EmptyDataText="No Data Found";
                gv.DataBind();
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        private void FillGrid(GridView gv)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Name");
                dt.Columns.Add("Id");
                DataRow dr;
                for (int i = 0; i < 100; i++)
                {
                    dr = dt.NewRow();
                    dr[0] = "AnyThing" + i;
                    dr[1] = i;
                    dt.Rows.Add(dr);
                }
               
                gv.DataSource = dt;
                
                 
            }
            catch (Exception ex)
            { 
            
            }
        }
        
