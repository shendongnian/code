    public int DropDownWidth(object[] objects, Font font)
    {
        int maxWidth = 0, temp = 0;
        foreach (var obj in objects)
        {
            temp = TextRenderer.MeasureText(obj.ToString(), font).Width;
            if (temp > maxWidth)
            {
                maxWidth = temp;
            }
        }
        return maxWidth;
    }
