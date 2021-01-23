    #region IsDirty
    /// <summary>
    /// IsDirty Attached Dependency Property
    /// </summary>
    public static readonly DependencyProperty IsDirtyProperty =
        DependencyProperty.RegisterAttached(
            "IsDirty",
            typeof(bool),
            typeof(AnimationHelper),
            new PropertyMetadata(false, OnIsDirtyChanged));
    /// <summary>
    /// Gets the IsDirty property. This dependency property 
    /// indicates blah blah blah.
    /// </summary>
    public static bool GetIsDirty(DependencyObject d)
    {
        return (bool)d.GetValue(IsDirtyProperty);
    }
    /// <summary>
    /// Sets the IsDirty property. This dependency property 
    /// indicates blah blah blah.
    /// </summary>
    public static void SetIsDirty(DependencyObject d, bool value)
    {
        d.SetValue(IsDirtyProperty, value);
    }
    /// <summary>
    /// Handles changes to the IsDirty property.
    /// </summary>
    /// <param name="d">
    /// The <see cref="DependencyObject"/> on which
    /// the property has changed value.
    /// </param>
    /// <param name="e">
    /// Event data that is issued by any event that
    /// tracks changes to the effective value of this property.
    /// </param>
    private static void OnIsDirtyChanged(
        DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        bool oldIsDirty = (bool)e.OldValue;
        bool newIsDirty = (bool)d.GetValue(IsDirtyProperty);
    }
    #endregion
