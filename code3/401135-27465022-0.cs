    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;
    using System.Xaml;
    /// <summary>
    /// Binds to the datacontext of the current root object
    /// </summary>
    [MarkupExtensionReturnType(typeof(object))]
    public class RootBinding : MarkupExtension
    {
        private static readonly DependencyObject DependencyObject = new DependencyObject();
        public RootBinding()
        {
        }
        public RootBinding(Binding binding)
        {
            Binding = binding;
        }
        public Binding Binding { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var provideValueTarget = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
            if (provideValueTarget == null)
            {
                throw new ArgumentException("provideValueTarget == null");
            }
            var rootObjectProvider = (IRootObjectProvider)serviceProvider.GetService(typeof(IRootObjectProvider));
            if (rootObjectProvider == null)
            {
                if (DesignerProperties.GetIsInDesignMode(DependencyObject))
                {
                    var dependencyProperty = (DependencyProperty) provideValueTarget.TargetProperty;
                    return dependencyProperty.DefaultMetadata.DefaultValue;
                }
                throw new ArgumentException("rootObjectProvider == null");
            }
            if (Binding == null)
            {
                throw new ArgumentException("Binding == null");
            }
            string path = string.Format("{0}.{1}", FrameworkElement.DataContextProperty.Name, Binding.Path.Path);
            var binding = new Binding(path)
            {
                Source = rootObjectProvider.RootObject,
                Mode = Binding.Mode,
                UpdateSourceTrigger = Binding.UpdateSourceTrigger,
                Converter = Binding.Converter,
                ConverterCulture = Binding.ConverterCulture,
                ConverterParameter = Binding.ConverterParameter
            };
            var provideValue = binding.ProvideValue(serviceProvider);
            return provideValue;
        }
    }
<!-- -->
