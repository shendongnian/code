    /// <summary>
    /// Calculates the widget 'count' for a given control using the
    /// Wicker-Bartland meanest minimum average algorithm.
    /// </summary>
    ///
    /// <param name="control">
    /// The Wicker-Bartland control-input-value, in the range 1.0 .. 42.6
    /// </param> 
    ///
    /// <returns>
    /// The widget count, in the range -2PI .. +2PI, or Double.NaN if the
    /// input control value is out of range.
    /// </returns>
