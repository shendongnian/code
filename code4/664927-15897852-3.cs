    public class MyDataTrigger : TriggerBase<FrameworkElement>
    {
        ...
        public BindingBase Binding
        {
            get;
            set;
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            if (Binding != null && this.AssociatedObject.DataContext != null)
                //
                // Adding a property changed listener..
                //
                Type type = Binding.GetType();
                PropertyPath propertyPath = (PropertyPath)(type.GetProperty("Path").GetValue(Binding));
                string propertyName = propertyPath.Path;
                TypeDescriptor.GetProperties(this.AssociatedObject.DataContext).Find(propertyName, false).AddValueChanged(this.AssociatedObject.DataContext, PropertyListener_ValueChanged);
        }
        
        private void PropertyListener_ValueChanged(object sender, EventArgs e)
        {
            // Do some stuff here..
        }
    }
