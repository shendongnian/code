    var computerFonts = FontColors.AsEnumerable().Select(f =>
    new ComputerFontColors
    {
      FontColor = f.Color,
      FontName = f.Fonts.Name,
      ComputerUsedOn = ComputerServices.GetByFontId(f.Fonts.Id)
    });
