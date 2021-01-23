    private void UpdateDisplay() {
      // Update the gradients, and place the 
      // pointers correctly based on colors and 
      // brightness.
      using (Brush selectedBrush = new SolidBrush(selectedColor)) {      
        using (Matrix m = new Matrix()) {
          m.RotateAt(35f, centerPoint);
          g.Transform = m;
          // Draw the saved color wheel image.
          g.DrawImage(colorImage, colorRectangle);
          g.ResetTransform();
        }
        // Draw the "selected color" rectangle.
        g.FillRectangle(selectedBrush, selectedColorRectangle);
        // Draw the "brightness" rectangle.
        DrawLinearGradient(fullColor);
        // Draw the two pointers.
        DrawColorPointer(colorPoint);
        DrawBrightnessPointer(brightnessPoint);
      }
    }
