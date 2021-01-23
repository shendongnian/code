    public Color GetContrastingColor(Color backColor)
    {
        int r = (int)backColor.R;
        int g = (int)backColor.G;
        int b = (int)backColor.B;
        int yiqSpace = ((r * 299) + (g * 587) + (b * 114)) / 1000;
        if (yiqSpace > 131)
        {
            return Color.Black;
        }
        else
        {
            return Color.White;
        }
    }
