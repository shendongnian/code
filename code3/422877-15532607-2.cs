    using System;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;
    namespace WpfApplication2
    {
        /// <summary>
        /// Creates a normal Binding but defaults NotifyOnValidationError and ValidatesOnExceptions to True,
        /// Mode to TwoWay and UpdateSourceTrigger to LostFocus.
        /// </summary>
        [MarkupExtensionReturnType(typeof(Binding))]
        public sealed class ValidatedBinding : MarkupExtension
        {
            public ValidatedBinding(string path)
            {
                Mode = BindingMode.TwoWay;
                UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
                Path = path;
            }
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                var Target = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
                /* on combo boxes, use an immediate update and validation */
                DependencyProperty DP = Target.TargetProperty as DependencyProperty;
                if (DP != null && DP.OwnerType == typeof(System.Windows.Controls.Primitives.Selector)
                    && UpdateSourceTrigger == UpdateSourceTrigger.LostFocus) {
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                }
                return new Binding(Path) {
                    Converter = this.Converter,
                    ConverterParameter = this.ConverterParameter,
                    ElementName = this.ElementName,
                    FallbackValue = this.FallbackValue,
                    Mode = this.Mode,
                    NotifyOnValidationError = true,
                    StringFormat = this.StringFormat,
                    ValidatesOnExceptions = true,
                    UpdateSourceTrigger = this.UpdateSourceTrigger
                };
            }
            public IValueConverter Converter { get; set; }
            public object ConverterParameter { get; set; }
            public string ElementName { get; set; }
            public object FallbackValue { get; set; }
            public BindingMode Mode { get; set; }
            [ConstructorArgument("path")]
            public string Path { get; set; }
            public string StringFormat { get; set; }
            public UpdateSourceTrigger UpdateSourceTrigger { get; set; }
        }
    }
