    switch (unitSize.Unit.Type)
            {
                case UnitType.Pixel:
                    result = (int)Math.Round(unitSize.Unit.Value);
                    break;
                case UnitType.Point:
                    result = (int)Math.Round(unitSize.Unit.Value*1.33);
                    break;
                case UnitType.Em:
                    result = (int)Math.Round(unitSize.Unit.Value * 16);
                    break;
                case UnitType.Percentage:
                    result = (int)Math.Round(unitSize.Unit.Value * 16 / 100);
                    break;
                default:
                    // other types are not supported. just return the medium
                    result = 16;
                    break;
            }
