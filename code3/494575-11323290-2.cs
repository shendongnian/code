     settings.Columns.Add(column =>
                                    {
                                     column.FieldName = "Id";
                                     column.Caption = " ";
                                     column.Settings.AllowAutoFilter = DefaultBoolean.False;
                                     column.Settings.AllowDragDrop = DefaultBoolean.False;
                                     column.Settings.AllowSort = DefaultBoolean.False;
                                    });
     settings.CustomColumnDisplayText = (sender, e) =>
                                              {
                                                    if (e.Column.FieldName == "Id")
                                                    {
                                                         e.DisplayText = // put your actionlink here                                                                                       
                                                    }
                                              };
