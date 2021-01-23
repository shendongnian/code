            // Paint the base content
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState,
               value, formattedValue, errorText, cellStyle,
               advancedBorderStyle, paintParts);
            if (this.Image != null)
            {
                PointF p = cellBounds.Location;
                p.X += 0;
                p.Y += 4;
                graphics.DrawImage(this.Image, p);
            }
        }
