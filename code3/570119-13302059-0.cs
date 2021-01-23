    private int cellValue = 4354;
    private void TelerikRadGridView_CellFormatting(object sender, CellFormattingEventArgs e)
    {
        e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
        e.CellElement.ResetValue(LightVisualElement.NumberOfColorsProperty, ValueResetFlags.Local);
        e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
        e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
 
        if (dontRunHandler == false)
        {
            if (e.CellElement.ColumnIndex != 2 
            && e.CellElement.ColumnIndex != 3 
            && e.CellElement.ColumnIndex != 4
            && e.CellElement.ColumnIndex != 5 
            && e.CellElement.ColumnIndex != 7 
            && e.CellElement.ColumnIndex != 11 
            && e.CellElement.ColumnIndex != 12 
            && e.CellElement.ColumnIndex != 13) return;
            else
            {
               if(e.CellElement.Value != null)
               {
                   if (Double.Parse(e.CellElement.Value.ToString()) != cellValue)
                   {
                       e.CellElement.DrawFill = true;
                       e.CellElement.NumberOfColors = 1;
                       e.CellElement.BackColor = Color.LightSlateGray;
                       e.CellElement.GradientStyle = GradientStyles.Linear;
                   }
                   else
                   {
                       e.CellElement.DrawFill = true;
                       e.CellElement.NumberOfColors = 1;
                       e.CellElement.BackColor = Color.Gold;
                       e.CellElement.GradientStyle = GradientStyles.Linear;
                   }
               }
            }
        }
