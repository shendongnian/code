     public class ReadonlyBinding : BindingDecoratorBase
     {
        private DependencyProperty _targetProperty = null;
        public ReadonlyBinding()
        : base()
        {
            Binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        }
        public override object ProvideValue(IServiceProvider provider)
        {
            // Get the binding expression
            object bindingExpression = base.ProvideValue(provider);
            // Bound items
            DependencyObject targetObject;
           
            // Try to get the bound items
            if (TryGetTargetItems(provider, out targetObject, out _targetProperty))
            {
                if (targetObject is FrameworkElement)
                {
                    // Get the element and implement datacontext changes
                    FrameworkElement element = targetObject as FrameworkElement;
                    element.DataContextChanged += new DependencyPropertyChangedEventHandler(element_DataContextChanged);
                }
            }
            // Go on with the flow
            return bindingExpression;
        }
        void element_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            object datacontext = e.NewValue;
            if (datacontext != null && _targetProperty != null)
            {
                PropertyInfo property = datacontext.GetType().GetProperty(Binding.Path.Path);
                if (property != null)
                {
                    var attribute = property.GetCustomAttributes(true).Where(o => o is IEditatble).FirstOrDefault();
                    if (attribute != null)
                    {                        
                        Control cntrl = sender as Control;
                        ((IEditatble)attribute).SetValue(cntrl, _targetProperty);
                    }
                }
            }
        }
    }
