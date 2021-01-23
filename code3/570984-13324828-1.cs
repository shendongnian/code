     e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
            e.CellElement.ResetValue(LightVisualElement.NumberOfColorsProperty, ValueResetFlags.Local);
            e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
            e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
    
            if (e.CellElement.ColumnIndex == 2 || e.CellElement.ColumnIndex == 3)
            {
                e.CellElement.DrawFill = true;
                e.CellElement.NumberOfColors = 1;
                e.CellElement.BackColor = Color.LightSlateGray;
                e.CellElement.GradientStyle = GradientStyles.Linear;
            }
    
            else if (e.CellElement.ColumnIndex == 0 || e.CellElement.ColumnIndex == 1)
            {
                e.CellElement.DrawFill = true;
                e.CellElement.NumberOfColors = 1;
                e.CellElement.BackColor = Color.MediumVioletRed;
                e.CellElement.GradientStyle = GradientStyles.Linear;
            }
