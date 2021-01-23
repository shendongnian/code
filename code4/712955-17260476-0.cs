    public Texture2D CreateRoundedRectangleTexture(GraphicsDevice graphics, int width, int height, int borderThickness, int borderRadius, int borderShadow, List<Color> backgroundColors, List<Color> borderColors, float initialShadowIntensity, float finalShadowIntensity)
    {
        if (backgroundColors == null || backgroundColors.Count == 0) throw new ArgumentException("Must define at least one background color (up to four).");
        if (borderColors == null || borderColors.Count == 0) throw new ArgumentException("Must define at least one border color (up to three).");
        if (borderRadius < 1) throw new ArgumentException("Must define a border radius (rounds off edges).");
        if (borderThickness < 1) throw new ArgumentException("Must define border thikness.");
        if (borderThickness + borderRadius > height / 2 || borderThickness + borderRadius > width / 2) throw new ArgumentException("Border will be too thick and/or rounded to fit on the texture.");
        if (borderShadow > borderRadius) throw new ArgumentException("Border shadow must be lesser in magnitude than the border radius (suggeted: shadow <= 0.25 * radius).");
        Texture2D texture = new Texture2D(graphics, width, height, false, SurfaceFormat.Color);
        Color[] color = new Color[width * height];
        for (int x = 0; x < texture.Width; x++)
        {
            for (int y = 0; y < texture.Height; y++)
            {
                switch (backgroundColors.Count)
                {
                    case 4:
                        Color leftColor0 = Color.Lerp(backgroundColors[0], backgroundColors[1], ((float)y / (width - 1)));
                        Color rightColor0 = Color.Lerp(backgroundColors[2], backgroundColors[3], ((float)y / (height - 1)));
                        color[x + width * y] = Color.Lerp(leftColor0, rightColor0, ((float)x / (width - 1)));
                        break;
                    case 3:
                        Color leftColor1 = Color.Lerp(backgroundColors[0], backgroundColors[1], ((float)y / (width - 1)));
                        Color rightColor1 = Color.Lerp(backgroundColors[1], backgroundColors[2], ((float)y / (height - 1)));
                        color[x + width * y] = Color.Lerp(leftColor1, rightColor1, ((float)x / (width - 1)));
                        break;
                    case 2:
                        color[x + width * y] = Color.Lerp(backgroundColors[0], backgroundColors[1], ((float)x / (width - 1)));
                        break;
                    default:
                        color[x + width * y] = backgroundColors[0];
                        break;
                }
                color[x + width * y] = ColorBorder(x, y, width, height, borderThickness, borderRadius, borderShadow, color[x + width * y], borderColors, initialShadowIntensity, finalShadowIntensity);
            }
        }
        texture.SetData<Color>(color);
        return texture;
    }
    private Color ColorBorder(int x, int y, int width, int height, int borderThickness, int borderRadius, int borderShadow, Color initialColor, List<Color> borderColors, float initialShadowIntensity, float finalShadowIntensity)
    {
        Rectangle internalRectangle = new Rectangle((borderThickness + borderRadius), (borderThickness + borderRadius), width - 2 * (borderThickness + borderRadius), height - 2 * (borderThickness + borderRadius));
        if (internalRectangle.Contains(x, y)) return initialColor;
        Vector2 origin = Vector2.Zero;
        Vector2 point = new Vector2(x, y);
        if (x < borderThickness + borderRadius)
        {
            if (y < borderRadius + borderThickness)
                origin = new Vector2(borderRadius + borderThickness, borderRadius + borderThickness);
            else if (y > height - (borderRadius + borderThickness))
                origin = new Vector2(borderRadius + borderThickness, height - (borderRadius + borderThickness));
            else
                origin = new Vector2(borderRadius + borderThickness, y);
        }
        else if (x > width - (borderRadius + borderThickness))
        {
            if (y < borderRadius + borderThickness)
                origin = new Vector2(width - (borderRadius + borderThickness), borderRadius + borderThickness);
            else if (y > height - (borderRadius + borderThickness))
                origin = new Vector2(width - (borderRadius + borderThickness), height - (borderRadius + borderThickness));
            else
                origin = new Vector2(width - (borderRadius + borderThickness), y);
        }
        else
        {
            if (y < borderRadius + borderThickness)
                origin = new Vector2(x, borderRadius + borderThickness);
            else if (y > height - (borderRadius + borderThickness))
                origin = new Vector2(x, height - (borderRadius + borderThickness));
        }
        if (!origin.Equals(Vector2.Zero))
        {
            float distance = Vector2.Distance(point, origin);
            if (distance > borderRadius + borderThickness + 1)
            {
                return Color.Transparent;
            }
            else if (distance > borderRadius + 1)
            {
                if (borderColors.Count > 2)
                {
                    float modNum = distance - borderRadius;
                    if (modNum < borderThickness / 2)
                    {
                        return Color.Lerp(borderColors[2], borderColors[1], (float)((modNum) / (borderThickness / 2.0)));
                    }
                    else
                    {
                        return Color.Lerp(borderColors[1], borderColors[0], (float)((modNum - (borderThickness / 2.0)) / (borderThickness / 2.0)));
                    }
                }
                if (borderColors.Count > 0)
                    return borderColors[0];
            }
            else if (distance > borderRadius - borderShadow + 1)
            {
                float mod = (distance - (borderRadius - borderShadow)) / borderShadow;
                float shadowDiff = initialShadowIntensity - finalShadowIntensity;
                return DarkenColor(initialColor, ((shadowDiff * mod) + finalShadowIntensity));
            }
        }
        return initialColor;
    }
    private Color DarkenColor(Color color, float shadowIntensity)
    {
        return Color.Lerp(color, Color.Black, shadowIntensity);
    }
