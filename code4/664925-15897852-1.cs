    public class MyDataTrigger : TriggerBase<FrameworkElement>
    {
        ...
        #region ________________________________________  PropertyName
        public string PropertyName
        {
            get { return (string)GetValue(PropertyNameProperty); }
            set { SetValue(PropertyNameProperty, value); }
        }
        public static readonly DependencyProperty PropertyNameProperty =
            DependencyProperty.Register("PropertyName",
                                        typeof(string),
                                        typeof(MyDataTrigger),
                                        new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None));
        #endregion
        #region ________________________________________  Binding
        
        public object Binding
        {
            get { return (object)GetValue(BindingProperty); }
            set { SetValue(BindingProperty, value); }
        }
        public static readonly DependencyProperty BindingProperty =
            DependencyProperty.Register("Binding",
                                        typeof(object),
                                        typeof(MyDataTrigger),
                                        new FrameworkPropertyMetadata(null));
        
        #endregion
        protected override void OnAttached()
        {
            base.OnAttached();
            if (Binding != null && this.AssociatedObject.DataContext != null)
                //
                // Adding a property changed listener..
                //
                TypeDescriptor.GetProperties(this.AssociatedObject.DataContext).Find(PropertyName, false).AddValueChanged(this.AssociatedObject.DataContext, PropertyListener_ValueChanged);
        }
        
        private void PropertyListener_ValueChanged(object sender, EventArgs e)
        {
            // Do some stuff here..
        }
    }
