      protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);
            if (SummaryDataPropertyNames.Count > 0)
            {
                if (DataSource is BindingSource)
                {
                    var ds = (DataSource as BindingSource);
                    foreach (var prop in SummaryDataPropertyNames)
                    {
                        prop.Value = 0;
                        var col = this.Columns[prop.ColumnName];
                        foreach (var l in ds.List)
                        {
                            decimal val;
                            if (decimal.TryParse(Convert.ToString(l.GetType().GetProperty(col.DataPropertyName).GetValue(l, null)), out val))
                                prop.Value +=   val;
                        }
                        col.HeaderText = col.HeaderText.Split('[')[0].TrimEnd(' ') + " [" + prop.Value.ToString(prop.Format) + "]";
                    }
                }
            }
        }
