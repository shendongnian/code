    if (data is IConvertible) {
      double value = ((IConvertible)data).ToDouble();
      // do calculations
    }
    
    if (data is IComparable) {
      if (((IComparable)data).CompareTo(42) < 0) {
        // less than 42
      }
    }
