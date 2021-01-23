    /// <summary>
    /// Converts the specified string representation of a logical value to its Boolean equivalent, using the specified culture-specific formatting information.
    /// </summary>
    /// 
    /// <returns>
    /// true if <paramref name="value"/> equals <see cref="F:System.Boolean.TrueString"/>, or false if <paramref name="value"/> equals <see cref="F:System.Boolean.FalseString"/> or null.
    /// </returns>
    /// <param name="value">A string that contains the value of either <see cref="F:System.Boolean.TrueString"/> or <see cref="F:System.Boolean.FalseString"/>. </param><param name="provider">An object that supplies culture-specific formatting information. This parameter is ignored.</param><exception cref="T:System.FormatException"><paramref name="value"/> is not equal to <see cref="F:System.Boolean.TrueString"/> or <see cref="F:System.Boolean.FalseString"/>. </exception><filterpriority>1</filterpriority>
    [__DynamicallyInvokable]
    public static bool ToBoolean(string value, IFormatProvider provider)
    {
      if (value == null)
        return false;
      else
        return bool.Parse(value);
    }
