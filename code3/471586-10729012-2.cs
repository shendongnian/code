    using System;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;
    
    namespace WpfApplication
    {
        public sealed class ProposedValueValidationBindingExtension : MarkupExtension
        {
            private readonly Binding binding;
    
            public ProposedValueValidationBindingExtension(Binding binding)
            {
                if (binding == null)
                    throw new ArgumentNullException("binding");
    
                this.binding = binding;
            }
    
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                var provideValueTarget = serviceProvider != null ? serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget : null;
                if (provideValueTarget != null)
                    this.binding.ValidationRules.Add(new ProposedValueErrorValidationRule(provideValueTarget.TargetObject as DependencyObject, provideValueTarget.TargetProperty as DependencyProperty));
    
                return this.binding.ProvideValue(serviceProvider);
            }
        }
    }
