    private static void OnDefectIdChanged(DependencyObject defectImageControl, DependencyPropertyChangedEventArgs eventArgs)
    {
      var control = (DefectImages) defectImageControl;
      control.DefectID = (Guid)eventArgs.NewValue;
    }
    /// <summary>
    /// Registers a dependency property, enables us to bind to it via XAML
    /// </summary>
    public static readonly DependencyProperty DefectIdProperty = DependencyProperty.Register(
        "DefectID",
        typeof (Guid),
        typeof (DefectImages),
        new FrameworkPropertyMetadata(
          // use an empty Guid as default value
          Guid.Empty,
          // tell the binding system that this property affects how the control gets rendered
          FrameworkPropertyMetadataOptions.AffectsRender, 
          // run this callback when the property changes
          OnDefectIdChanged 
          )
        );
    /// <summary>
    /// DefectId accessor for for each instance of this control
    /// Gets and sets the underlying dependency property value
    /// </summary>
    public Guid DefectID
    {
      get { return (Guid) GetValue(DefectIdProperty); }
      set { SetValue(DefectIdProperty, value); }
    }
