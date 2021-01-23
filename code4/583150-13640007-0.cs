    if (Grid.Rows.Count > 1)
            {
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                    dtCurrentTable.Rows.RemoveAt(dtCurrentTable.Rows.Count -1);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    Grid.DataSource = dtCurrentTable;
                    Grid.DataBind();
        
                }
                else
                {
                    Response.Write("ViewState is null");
                }
            }
