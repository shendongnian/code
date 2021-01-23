    public static Boolean IsValidCurrency(this string value)
    {
      // Assume the worst.
      Boolean isValid = false;
      foreach (CultureInfo c in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
      {
        // Account for InvariantCulture weirdness in Windows 7.
        if (!c.Equals(CultureInfo.InvariantCulture))
        {
          RegionInfo r = new RegionInfo(c.LCID);
        
          if (r.CurrencySymbol.Equals(value, StringComparison.OrdinalIgnoreCase))
          {
            // We've got a match, so flag it and break.
            isValid = true;
            break;
          }
        }
      }
      return isValid;
    }
