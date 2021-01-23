    /// <summary>
    /// [static method] Generates a StringFormat object based on the ContentAlignment object
    /// </summary>
    /// <param name="ca">ContentAlignment value from a System.Windows.Label object</param>
    /// <returns>StringFormat</returns>
    private static StringFormat GetStringFormatFromContentAllignment(ContentAlignment ca) {
      StringFormat format = new StringFormat();
      switch (ca) {
        case ContentAlignment.TopCenter:
          format.Alignment = StringAlignment.Near;
          format.LineAlignment = StringAlignment.Center;
          break;
        case ContentAlignment.TopLeft:
          format.Alignment = StringAlignment.Near;
          format.LineAlignment = StringAlignment.Near;
          break;
        case ContentAlignment.TopRight:
          format.Alignment = StringAlignment.Near;
          format.LineAlignment = StringAlignment.Far;
          break;
        case ContentAlignment.MiddleCenter:
          format.Alignment = StringAlignment.Center;
          format.LineAlignment = StringAlignment.Center;
          break;
        case ContentAlignment.MiddleLeft:
          format.Alignment = StringAlignment.Center;
          format.LineAlignment = StringAlignment.Near;
          break;
        case ContentAlignment.MiddleRight:
          format.Alignment = StringAlignment.Center;
          format.LineAlignment = StringAlignment.Far;
          break;
        case ContentAlignment.BottomCenter:
          format.Alignment = StringAlignment.Far;
          format.LineAlignment = StringAlignment.Center;
          break;
        case ContentAlignment.BottomLeft:
          format.Alignment = StringAlignment.Far;
          format.LineAlignment = StringAlignment.Near;
          break;
        case ContentAlignment.BottomRight:
          format.Alignment = StringAlignment.Far;
          format.LineAlignment = StringAlignment.Far;
          break;
      }
      return format;
    }
