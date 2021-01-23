    var font = new System.Drawing.Font("Arial", 11f);
    int ascent = font.FontFamily.GetCellAscent(System.Drawing.FontStyle.Regular);
    int descent = font.FontFamily.GetCellDescent(System.Drawing.FontStyle.Regular);
    int height = font.FontFamily.GetEmHeight(System.Drawing.FontStyle.Regular);
    int lineSpacing = font.FontFamily.GetLineSpacing(System.Drawing.FontStyle.Regular);
    float pointSize = font.SizeInPoints;
