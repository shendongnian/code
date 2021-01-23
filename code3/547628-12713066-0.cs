    [Flags]
    enum Car
    {
      None = 0, 
      ModelFord = 1,
      ModelBmw = 2,
      ModelToyota = 4,
      ColorRed = 8,
      ColorBlack = 16,
      carA = ModelFord | ColorRed,
      carB = ModelBmw | ColorBlack,
      carC = ModelToyota  | ColorBlack
    }
