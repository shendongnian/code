    private const int MinLightness = 1;
    private const int MaxLightness = 10;
    private const float MinLightnessCoef = 0.4f;
    private const float MaxLightnessCoef = 1f;
    public static Color ChangeLightness(this Color color, int lightness)
    {
        if (lightness < MinLightness)
            lightness = MinLightness;
        else if (lightness > MaxLightness)
            lightness = MaxLightness;
        float coef = MinLightnessCoef +
        (((lightness - MinLightness) * ((MaxLightnessCoef - MinLightnessCoef)
            / (MaxLightness - MinLightness))));
        return Color.FromArgb((int)(color.R * coef), (int)(color.G * coef),
            (int)(color.B * coef));
    }
