    using Caliburn.Micro;
    using System.Windows;
    using Xceed.Wpf.Toolkit;
    
    namespace Test {
        public class AppBootstrapper : Bootstrapper<MainViewModel>{
    
            protected override void Configure() {
                base.Configure();
    
                //setup the conventions
                var valueConvention = ConventionManager.AddElementConvention<FrameworkElement>(IntegerUpDown.ValueProperty, "Value", "ValueChanged");
                var maximumConvention = ConventionManager.AddElementConvention<FrameworkElement>(IntegerUpDown.MaximumProperty, "Maximum", "ValueChanged");
                var minimumConvention = ConventionManager.AddElementConvention<FrameworkElement>(IntegerUpDown.MinimumProperty, "Minimum", "ValueChanged");
                
                //bind the properties
                var baseBindProperties = ViewModelBinder.BindProperties;
                ViewModelBinder.BindProperties =
                    (frameWorkElements, viewModels) => {
    
                        foreach (var frameworkElement in frameWorkElements) {
                            var valuePropertyName = frameworkElement.Name;
                            var valueProperty = viewModels
                                    .GetPropertyCaseInsensitive(valuePropertyName);
    
                            if (valueProperty != null) {
                                ConventionManager.SetBindingWithoutBindingOverwrite(
                                        viewModels,
                                        valuePropertyName,
                                        valueProperty,
                                        frameworkElement,
                                        valueConvention,
                                        valueConvention.GetBindableProperty(frameworkElement));
                            }
    
                            var maxPropertyName = frameworkElement.Name + "Maximum";
                            var maxProperty = viewModels
                                    .GetPropertyCaseInsensitive(maxPropertyName);
    
                            if (maxProperty != null) {
                                ConventionManager.SetBindingWithoutBindingOverwrite(
                                        viewModels,
                                        maxPropertyName,
                                        maxProperty,
                                        frameworkElement,
                                        maximumConvention,
                                        maximumConvention.GetBindableProperty(frameworkElement));
                            }
    
                            var minPropertyName = frameworkElement.Name + "Minimum";
                            var minProperty = viewModels
                                    .GetPropertyCaseInsensitive(minPropertyName);
    
                            if (minProperty != null) {
                                ConventionManager.SetBindingWithoutBindingOverwrite(
                                    viewModels,
                                    minPropertyName,
                                    minProperty,
                                    frameworkElement,
                                    minimumConvention,
                                    minimumConvention.GetBindableProperty(frameworkElement));
                            }
                        }
    
                        return baseBindProperties(frameWorkElements, viewModels);
                    };
    
            }
        }
    }
