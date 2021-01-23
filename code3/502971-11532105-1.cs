    public class LabelValidationHelper
    {
        public static FrameworkElement GetDetailControl(DependencyObject obj)
        {
            return (FrameworkElement)obj.GetValue(DetailControlProperty);
        }
        public static void SetDetailControl(DependencyObject obj, FrameworkElement value)
        {
            obj.SetValue(DetailControlProperty, value);
        }
        public static readonly DependencyProperty DetailControlProperty = DependencyProperty.RegisterAttached("DetailControl", typeof(FrameworkElement), typeof(LabelValidationHelper), new UIPropertyMetadata(null, OnDetailControlChanged));       
        private static void OnDetailControlChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            if (args.NewValue == null)
                return;
            var label = (Label)sender;
            var style = new Style(typeof(Label), label.Style);
            var binding = new Binding();
            binding.Source = args.NewValue;
            binding.Path = new PropertyPath(Validation.HasErrorProperty);
            var trigger = new DataTrigger();
            trigger.Binding = binding;
            trigger.Value = true;
            var setter = new Setter();
            setter.Property = Label.ForegroundProperty;
            setter.Value = Brushes.Red;
            trigger.Setters.Add(setter);
            style.Triggers.Add(trigger);
            label.Style = style;
        }
    }
