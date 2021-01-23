            if (ViewState["CurrentTable"] != null)
                dt = (DataTable)ViewState["CurrentTable"];            
            if (dt.Rows.Count > 0)
            {
                int Index = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["Pk"].ToString());
                dt.Rows.Cast<DataRow>().Where(o => o.Field<Int32>("Pk").Equals(Index)).FirstOrDefault().Delete();
               //  dt.Rows.RemoveAt(Index-1);
                gvDetails.DataSource = dt;
                gvDetails.DataBind();
            }
        }
