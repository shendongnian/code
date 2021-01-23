    query = resultQuery + "  SELECT '('+CONVERT(VARCHAR(10),@@ROWCOUNT)+' row(s) affected)' AS RESULT";
    DataSet result = DataSet result = SqlHelper.ExecuteDataset(CommandType.Text, query);
            
            if (result.DefaultViewManager.DataViewSettingCollectionString.Contains("Table") == true)
            {
                sqlGrid.Visible = true;
                sqlGrid.DataSource = result;
                sqlGrid.DataBind();
            }
            if (sqlGrid.Rows.Count==1 && sqlGrid.Rows[0].Cells.Count==1)
            {
                string text = (sqlGrid.Rows[0].Cells[0]).Text;
                if (text.Contains("row(s) affected"))
                {
                    lblInfo.Text=text;
                    lblInfo.Visible=true;
                    sqlGrid.DataSource = null;
                    sqlGrid.DataBind();
                }
            }
