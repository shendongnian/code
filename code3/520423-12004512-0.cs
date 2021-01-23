    foreach (System.Data.DataColumn c in pDates.Columns)
                {
                        f = new Infragistics.Web.UI.GridControls.BoundDataField(true);
                        f.DataFieldName = c.ColumnName;
                        f.Key = c.ColumnName;
                        f.Header.Text = c.ColumnName;
                        WebDataGrid1.Columns.Add(f);
    // In order to set it as readonly:
    columnSettingReadOnly = New Infragistics.Web.UI.GridControls.EditingColumnSetting();
                    columnSettingReadOnly.ColumnKey = f.Key;
                    columnSettingReadOnly.ReadOnly = True;
                    WebDataGrid1.Behaviors.EditingCore.Behaviors.CellEditing.ColumnSettings.Add(columnSettingReadOnly);
                }
