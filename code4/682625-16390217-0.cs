    /// <summary>
    /// The values are organized so that the note value + 10 is sharp, -10 is flat, for readability.
    /// For instance, Note.C - 10 = Note.CFlat, Note.C + 10 = Note.CSharp.
    /// </summary>
    public enum Note
    {
      Silent = 0,
    
      CFlat = -9,
      DFlat = -8,
      EFlat = -7,
      FFlat = -6,
      GFlat = -5,
      AFlat = -4,
      BFlat = -3,
      C = 1,
      D = 2,
      E = 3,
      F = 4,
      G = 5,
      A = 6,
      B = 7, 
      CSharp = 10,
      DSharp = 12,
      ESharp = 13,
      FSharp = 14,
      GSharp = 15,
      ASharp = 16,
      BSharp = 17,
    }
    /// <summary>
    /// Returns the note from a chromatic level.
    /// For instance: 1 = C, 2 = Db, 6 = F, etc.
    /// </summary>
    /// <param name="chromaticStep"></param>
    public static Note GetNote(int chromaticStep)
    {
      if (chromaticStep < 0 || chromaticStep > 12)
        throw new ArgumentOutOfRangeException("chromaticStep",
          "The value must be within the octave range.");
      var diatonicStep = (chromaticStep / 2) + 1;
      //determines whether it's in the upper half of the keyboard layout (> E)
      var isUpperHalf = chromaticStep > 5;
      var isOdd = chromaticStep % 2 != 0;
      var isChromatic = isUpperHalf ? isOdd : !isOdd;
      if (isChromatic)
        diatonicStep += isUpperHalf ? 10 : -10;
      return (Note)diatonicStep;
    }
