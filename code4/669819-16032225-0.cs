    using ReactiveUI.Subjects;
    using System;
    using System.Linq;
    using System.Reactive.Subjects;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;
    
    namespace ReactiveUI.Markup
    {
        [MarkupExtensionReturnType(typeof(BindingExpression))]
        public class SubscriptionExtension : MarkupExtension
        {
            [ConstructorArgument("path")]
            public PropertyPath Path { get; set; }
    
            public SubscriptionExtension() { }
    
            public SubscriptionExtension(PropertyPath path)
            {
                Path = Path;
            }
    
            class Proxy : ReactiveObject
            {
                string _Value;
                public string Value
                {
                    get { return _Value; }
                    set { this.RaiseAndSetIfChanged(value); }
                }
            }
    
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                var pvt = serviceProvider as IProvideValueTarget;
                if (pvt == null)
                {
                    return null;
                }
    
                var frameworkElement = pvt.TargetObject as FrameworkElement;
                if (frameworkElement == null)
                {
                    return this;
                }
    
    
                object propValue = GetProperty(frameworkElement.DataContext, Path.Path);
    
                var subject = propValue as ISubject<string>;
    
                var proxy = new Proxy();
                Binding binding = new Binding() 
                {
                    Source = proxy,
                    Path = new System.Windows.PropertyPath("Value")
                };
    
                // Bind the subject to the property via a helper ( in private library )
                var subscription = subject.ToMutableProperty(proxy, x => x.Value);
    
                // Make sure we don't leak subscriptions
                frameworkElement.Unloaded += (e,v) => subscription.Dispose(); 
    
                return binding.ProvideValue(serviceProvider);
            }
    
            private static object GetProperty(object context, string propPath)
            {
                object propValue = propPath
                    .Split('.')
                    .Aggregate(context, (value, name)
                        => value.GetType() 
                            .GetProperty(name)
                            .GetValue(value, null));
                return propValue;
            }
    
        }
    }
