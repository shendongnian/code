                foreach (DataTable dataTable in dataSet.Tables)
            {
                form1.Controls.Add(new LiteralControl(String.Format("<h1>{0}</h1>", dataTable.TableName)));
                GridView grid = new GridView();
                grid.AllowPaging = false;
                grid.AutoGenerateColumns = false;
                foreach (DataColumn col in dataTable.Columns)
                {
                    grid.Columns.Add(new BoundField { DataField = col.ColumnName, HeaderText = col.Caption });
                }
                grid.DataSource = dataTable;
                grid.DataBind();
                form1.Controls.Add(grid);
            }
