    public class RowDataValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            BindingGroup group = (BindingGroup)value;
            foreach (var item in group.Items)
            {
                DataRowView rowView = item as DataRowView;
                DataRow row;
                if (rowView != null)
                    row = rowView.Row;
                else
                    row = item as DataRow;
                if (row != null && row.HasErrors)
                {
                    var errorColumns = row.GetColumnsInError();
                    StringBuilder sb = new StringBuilder();
                    foreach (var column in errorColumns)
                    {
                        sb.AppendLine(row.GetColumnError(column));
                    }
                    return new ValidationResult(false, sb.ToString());
                }
               
            }
            return ValidationResult.ValidResult;
        }
    }
