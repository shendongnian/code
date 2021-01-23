    enum NumberKind {
      Int32,
      Decimal,
      Hexa
    }
    string ConvertNumber(NumberKind inputKind, string inputValue, NumberKind outputKind) {
      IConvertible intermediate;
      switch (inputKind) {
      case NumberKind.Int32:
        intermediate = Int32.Parse(inputValue, NumberStyles.Integer, CultureInfo.InvariantCulture);
        break;
      case NumberKind.Decimal:
        intermediate = Decimal.Parse(inputValue, NumberStyles.Number, CultureInfo.InvariantCulture);
        break;
      case NumberKind.Hexa:
        intermediate = Int32.Parse(inputValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
        break;
      }
      switch (outputKind) {
      case NumberKind.Int32:
        return intermediate.ToInt32().ToString("D", CultureInfo.InvariantCulture);
      case NumberKind.Decimal:
        return intermediate.ToDecimal().ToString("G", CultureInfo.InvariantCulture);
      case NumberKind.Hexa:
        return intermediate.ToInt32().ToString("X", CultureInfo.InvariantCulture);
      }
    }
