    private SizeF GetMaxSize(List<string> items)
    {
        Graphics g = CreateGraphics();
        SizeF size;
        SizeF oldSize = new Size(0f,0f);
        foreach(string item in items)
        {
            size = g.MeasureString(item, myComboBox.Font);
            if (size.Width > oldSize.Width) {
                oldSize.Width = size.Width
                oldSize.Height = size.Height
            }
        }
        return oldSize;
    }
