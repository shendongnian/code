    var font = new System.Drawing.Font("Arial", 11f);
    var style = System.Drawing.FontStyle.Regular;
    var ff = font.FontFamily;
    int ascent = ff.GetCellAscent(style);
    int descent = ff.GetCellDescent(style);
    int height = ff.GetEmHeight(style);
    int lineSpacing = ff.GetLineSpacing(style);
    float pointSize = font.SizeInPoints;
