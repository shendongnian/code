    /// <summary>
    /// Appends the default line terminator to the end of the current <see cref="T:System.Text.StringBuilder"/> object.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// A reference to this instance after the append operation has completed.
    /// 
    /// </returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="P:System.Text.StringBuilder.MaxCapacity"/>.
    ///                 </exception><filterpriority>1</filterpriority>
    [ComVisible(false)]
    [__DynamicallyInvokable]
    public StringBuilder AppendLine()
    {
      return this.Append(Environment.NewLine);
    }
