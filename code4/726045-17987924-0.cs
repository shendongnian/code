            string query;
            query = "....SQL...";
            {
                conn.Open();
                using (OracleDataAdapter a = new OracleDataAdapter(query, conn))
                {
                    DataTable t = new DataTable();
                    a.Fill(t);
                    dgSku.TableStyles.Clear();
                    DataGridTableStyle tableStyle = new DataGridTableStyle();
                    tableStyle.MappingName = t.TableName;
                    foreach (DataColumn item in t.Columns)
                    {
                        DataGridTextBoxColumn tbcName = new DataGridTextBoxColumn();
                        tbcName.Width = 80;
                        tbcName.MappingName = item.ColumnName;
                        tbcName.HeaderText = item.ColumnName;
                        tableStyle.GridColumnStyles.Add(tbcName);
                    }
                    dgSku.TableStyles.Add(tableStyle);
                }
            }
