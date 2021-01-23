        private void BuildPreviewGridColumns()
        {
            if (_dynamicReportPreview == null)
                return;
            _dynamicReportPreview.Columns.Clear();
            var initialFields = ViewModel.ReportFields.OrderBy(rf => rf.SelectOrder);
            foreach (var rf in initialFields)
            {
                var col = new Column
                {
                    ColumnName = rf.FieldName, 
                    Binding = new Binding(rf.FieldName)
                };
                _dynamicReportPreview.Columns.Add(col);
                if (!rf.IsVisible)
                {
                    col.Visible = false;
                }
            }
        }
