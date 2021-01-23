    public sealed class PropertyManager : TriggerAction<FrameworkElement>
    {
        #region Fields
    
        private bool _bindingUpdating;
        private PropertyInfo _currentProperty;
        private bool _propertyUpdating;
    
        #endregion
    
        #region Dependency properties
    
        /// <summary>
        ///     Identifies the <see cref="Binding" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BindingProperty =
            DependencyProperty.Register("Binding", typeof(object), typeof(PropertyManager),
                new PropertyMetadata((o, args) =>
                {
                    var propertyManager = o as PropertyManager;
                    if (propertyManager == null ||
                        args.OldValue == args.NewValue) return;
                    propertyManager.TrySetProperty(args.NewValue);
                }));
    
        /// <summary>
        ///     Identifies the <see cref="SourceProperty" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SourcePropertyProperty =
            DependencyProperty.Register("SourceProperty", typeof(string), typeof(PropertyManager),
                new PropertyMetadata(default(string)));
    
        /// <summary>
        ///     Binding for property <see cref="SourceProperty" />.
        /// </summary>
        public object Binding
        {
            get { return GetValue(BindingProperty); }
            set { SetValue(BindingProperty, value); }
        }
    
        /// <summary>
        ///     Name property to bind.
        /// </summary>
        public string SourceProperty
        {
            get { return (string)GetValue(SourcePropertyProperty); }
            set { SetValue(SourcePropertyProperty, value); }
        }
    
        #endregion
    
        #region Methods
    
        /// <summary>
        ///     Invokes the action.
        /// </summary>
        /// <param name="parameter">
        ///     The parameter to the action. If the action does not require a parameter, the parameter may be
        ///     set to a null reference.
        /// </param>
        protected override void Invoke(object parameter)
        {
            TrySetBinding();
        }
    
        /// <summary>
        ///     Tries to set binding value.
        /// </summary>
        private void TrySetBinding()
        {
            if (_propertyUpdating) return;
            PropertyInfo propertyInfo = GetPropertyInfo();
            if (propertyInfo == null) return;
            if (!propertyInfo.CanRead)
                return;
            _bindingUpdating = true;
            try
            {
                Binding = propertyInfo.GetValue(AssociatedObject, null);
            }
            finally
            {
                _bindingUpdating = false;
            }
        }
    
        /// <summary>
        ///     Tries to set property value.
        /// </summary>
        private void TrySetProperty(object value)
        {
            if (_bindingUpdating) return;
            PropertyInfo propertyInfo = GetPropertyInfo();
            if (propertyInfo == null) return;
            if (!propertyInfo.CanWrite)
                return;
            _propertyUpdating = true;
            try
            {
                propertyInfo.SetValue(AssociatedObject, value, null);
            }
            finally
            {
                _propertyUpdating = false;
            }
        }
    
        private PropertyInfo GetPropertyInfo()
        {
            if (_currentProperty != null && _currentProperty.Name == SourceProperty)
                return _currentProperty;
            if (AssociatedObject == null)
                throw new NullReferenceException("AssociatedObject is null.");
            if (string.IsNullOrEmpty(SourceProperty))
                throw new NullReferenceException("SourceProperty is null.");
            _currentProperty = AssociatedObject
                .GetType()
                .GetProperty(SourceProperty);
            if (_currentProperty == null)
                throw new NullReferenceException("Property not found in associated object, property name: " +
                                                    SourceProperty);
            return _currentProperty;
        }
    
        #endregion
    }
