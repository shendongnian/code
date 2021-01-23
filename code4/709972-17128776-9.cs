    string number = "10";
    float emSize = 10f;
    SizeF textSize = SizeF.Empty;
    Font font = null;
    do
    {
         emSize++;
         font = new System.Drawing.Font(new FontFamily("Times New Roman"), emSize);
         textSize = e.Graphics.MeasureString(number, font);
    }
    while (panel1.Width > textSize.Width && panel1.Height > textSize.Height);
    font = new System.Drawing.Font(new FontFamily("Times New Roman"), --emSize);
