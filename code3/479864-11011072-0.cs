    class AttachedBehaviours
    {
        public static bool GetAllowTargetUpdated(DependencyObject obj)
        {
            return (bool)obj.GetValue(AllowTargetUpdatedProperty);
        }
        public static void SetAllowTargetUpdated(DependencyObject obj, bool value)
        {
            obj.SetValue(AllowTargetUpdatedProperty, value);
        }
        // Using a DependencyProperty as the backing store for AllowTargetUpdated.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AllowTargetUpdatedProperty =
            DependencyProperty.RegisterAttached("AllowTargetUpdated", typeof(bool), typeof(AttachedBehaviours), new UIPropertyMetadata(false, PropChanged));
        static void PropChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var ele = obj as FrameworkElement;
            var be = ele.GetBindingExpression(TextBlock.TextProperty);
            if (be == null) return;
            var b = be.ParentBinding;
            
            var newBinding = new Binding(b.Path.Path);
            newBinding.NotifyOnTargetUpdated = (bool)e.NewValue;
            ele.SetBinding(TextBlock.TextProperty, newBinding);
        }
    }
