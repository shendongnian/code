    using System;
    using System.Windows;
    using System.Windows.Controls;
    public static class Filter
    {
        public static readonly DependencyProperty WithProperty = DependencyProperty.RegisterAttached(
            "With",
            typeof(Predicate<object>),
            typeof(Filter),
            new PropertyMetadata(default(Predicate<object>), OnWithChanged));
        public static void SetWith(ItemsControl element, Predicate<object> value)
        {
            element.SetValue(WithProperty, value);
        }
        public static Predicate<object> GetWith(ItemsControl element)
        {
            return (Predicate<object>)element.GetValue(WithProperty);
        }
        private static void OnWithChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpdateFilter((ItemsControl)d, (Predicate<object>)e.NewValue);
        }
        private static void UpdateFilter(ItemsControl itemsControl, Predicate<object> filter)
        {
            if (itemsControl.Items.CanFilter)
            {
                itemsControl.Items.Filter = filter;
            }
        }
    }
