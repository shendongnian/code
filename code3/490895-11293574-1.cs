    for (int i = 0; i < dt.Columns.Count; i++)
            {
                JQGridColumn col = new JQGridColumn();
                col.DataField = lstCol[i].ColumnName;
                col.HeaderText = lstCol[i].ColumnName;
                col.Width = lstCol[i].ColumnName.Length;
                col.Visible = true;
                col.Editable = true;
                if (i == 0)
                {
                    col.PrimaryKey = true;
                }
                JQGrid1.Columns.Add(col);
            }
