    Double d;
     
    if (Double.TryParse(test.Class, NumberStyles.Any, CultureInfo.InvariantCulture, out d)) {
      Int32 i = (Int32) d;
      // <- Do something with i
    }
    else {
      // <- test.Class is of incorrect format
    }
