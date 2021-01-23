    using ITIS.Reflection /* you can replace this with System.Reflection */;
    using System;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;
    namespace ITIS
    {
        /// <summary>
        /// Creates a Binding with the following defaults:
        /// <para>- NotifyOnValidationError = True, </para>
        /// <para>- ValidatesOnExceptions = True, </para>
        /// <para>- Mode = TwoWay, </para> 
        /// <para>- UpdateSourceTrigger = LostFocus for 'Text' properties, otherwise PropertyChanged.</para>
        /// </summary>
    #if !SILVERLIGHT
        [MarkupExtensionReturnType(typeof(Binding))]
    #endif
        public sealed class ValidatedBinding : MarkupExtension
        {
            #region CONSTRUCTOR
            public ValidatedBinding(string path)
            {
                Mode = BindingMode.TwoWay;
                Path = path;
                /* possibly changed again in ProvideValue() */
                UpdateSourceTrigger = UpdateSourceTrigger.Default;
            }
            #endregion
            #region PROPERTIES
            public IValueConverter Converter { get; set; }
            public object ConverterParameter { get; set; }
            public string ElementName { get; set; }
            public object FallbackValue { get; set; }
            public BindingMode Mode { get; set; }
    #if !SILVERLIGHT
            [ConstructorArgument("path")]
    #endif
            public string Path { get; set; }
            public string StringFormat { get; set; }
            public UpdateSourceTrigger UpdateSourceTrigger { get; set; }
            #endregion
            #region FIELDS
            bool _bound;
            DependencyProperty _property;
            FrameworkElement _element;
            #endregion
            #region OPERATIONS
            void ClearBinding()
            {
                _element.ClearValue(_property);
            }
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                IProvideValueTarget Target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
                if (Target == null) {
                    throw new InvalidOperationException(
                        "Cannot resolve the IProvideValueTarget. Are you binding to a property?");
                }
    #if !SILVERLIGHT
                /* on text boxes, use a LostFocus update trigger */
                _property = Target.TargetProperty as DependencyProperty;
                if (_property != null) {
                    if (_property.Name.StartsWith("Text")) {
                        UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
                    }
                    else {
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    }
                }
    #endif
                _element = Target.TargetObject as FrameworkElement;
                if (_element != null) {
                    _element.DataContextChanged += Element_DataContextChanged_SetBinding;
                    if (_element.DataContext != null || !string.IsNullOrWhiteSpace(ElementName)) {
                        SetBinding();
                        /* can be replaced with normal reflection PropertyInfo.GetValue() */
                        return FastReflector.GetPropertyValue(/* object = */ _element.DataContext, /* property name = */ Path);
                    }
                    /* don't return null for value types */
                    if (_property.PropertyType.IsValueType) {
                        return Activator.CreateInstance(_property.PropertyType);
                    }
                    return null;
                }
                return this;
            }
            void SetBinding()
            {
                _bound = true;
                Binding Binding = new Binding() {
                    Path = new PropertyPath(this.Path),
                    Converter = this.Converter,
                    ConverterParameter = this.ConverterParameter,
                    FallbackValue = this.FallbackValue,
                    Mode = this.Mode,
                    NotifyOnValidationError = true,
                    StringFormat = this.StringFormat,
                    ValidatesOnExceptions = true,
                    UpdateSourceTrigger = this.UpdateSourceTrigger
                };
                /* only set when necessary to avoid a validation exception from the binding */
                if (_element.DataContext != null) { Binding.Source = _element.DataContext; }
                if (!string.IsNullOrWhiteSpace(ElementName)) { Binding.ElementName = ElementName; }
                _element.SetBinding(_property, Binding);
            }
            #endregion
            #region EVENT HANDLERS
            void Element_DataContextChanged_SetBinding(object sender, DependencyPropertyChangedEventArgs e)
            {
                /* cleanup the old binding */
                if (_bound) { ClearBinding(); }
                SetBinding();
            }
            #endregion
        }
    }
