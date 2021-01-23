    /// <summary>
    /// Adapted from https://msdn.microsoft.com/en-us/library/ms171619.aspx. Double-buffering was added to remove flicker on re-paints.
    /// </summary>
    public class DataGridViewDisableButtonCell : DataGridViewButtonCell
    {
        private bool enabledValue;
        public bool Enabled
        {
            get { return enabledValue; }
            set
            {
                if (enabledValue == value) return;
                enabledValue = value;
                // force the cell to be re-painted
                if (DataGridView != null) DataGridView.InvalidateCell(this);
            }
        }
        // Override the Clone method so that the Enabled property is copied. 
        public override object Clone()
        {
            var cell = (DataGridViewDisableButtonCell) base.Clone();
            cell.Enabled = Enabled;
            return cell;
        }
        // By default, enable the button cell. 
        public DataGridViewDisableButtonCell()
        {
            enabledValue = true;
        }
        protected override void Paint(
            Graphics graphics,
            Rectangle clipBounds,
            Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates elementState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            // The button cell is disabled, so paint the border, background, and disabled button for the cell. 
            if (!enabledValue)
            {
                var currentContext = BufferedGraphicsManager.Current;
                using (var myBuffer = currentContext.Allocate(graphics, cellBounds))
                {
                    // Draw the cell background, if specified. 
                    if ((paintParts & DataGridViewPaintParts.Background) == DataGridViewPaintParts.Background)
                    {
                        using (var cellBackground = new SolidBrush(cellStyle.BackColor))
                        {
                            myBuffer.Graphics.FillRectangle(cellBackground, cellBounds);
                        }
                    }
                    // Draw the cell borders, if specified. 
                    if ((paintParts & DataGridViewPaintParts.Border) == DataGridViewPaintParts.Border)
                    {
                        PaintBorder(myBuffer.Graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
                    }
                    // Calculate the area in which to draw the button.
                    var buttonArea = cellBounds;
                    var buttonAdjustment = BorderWidths(advancedBorderStyle);
                    buttonArea.X += buttonAdjustment.X;
                    buttonArea.Y += buttonAdjustment.Y;
                    buttonArea.Height -= buttonAdjustment.Height;
                    buttonArea.Width -= buttonAdjustment.Width;
                    // Draw the disabled button.                
                    ButtonRenderer.DrawButton(myBuffer.Graphics, buttonArea, PushButtonState.Disabled);
                    // Draw the disabled button text.  
                    var formattedValueString = FormattedValue as string;
                    if (formattedValueString != null)
                    {
                        TextRenderer.DrawText(myBuffer.Graphics, formattedValueString, DataGridView.Font, buttonArea, SystemColors.GrayText, TextFormatFlags.PreserveGraphicsTranslateTransform | TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                    myBuffer.Render();
                }
            }
            else
            {
                // The button cell is enabled, so let the base class handle the painting. 
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            }
        }
    }
