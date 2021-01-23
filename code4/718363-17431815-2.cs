    public static class PixelBasedScrollingBehavior
    {
        public static bool GetIsEnabled (DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnabledProperty);
        }
        public static void SetIsEnabled (DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnabledProperty, value);
        }
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(PixelBasedScrollingBehavior),
                new UIPropertyMetadata(false, IsEnabledChanged));
        private static void IsEnabledChanged (DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var isEnabled = (bool)e.NewValue;
            if (d is VirtualizingPanel) {
                if (TrySetScrollUnit(d, isEnabled))
                    return;
                if (!TrySetIsPixelBased(d, isEnabled))
                    throw new InvalidOperationException("Failed to set IsPixelBased or ScrollUnit property.");
            }
            if (d is ItemsControl) {
                TrySetScrollUnit(d, isEnabled);
            }
        }
        private static bool TrySetScrollUnit (DependencyObject ctl, bool isEnabled)
        {
            // .NET 4.5: ctl.SetValue(VirtualizingPanel.ScrollUnitProperty, isEnabled ? ScrollUnit.Pixel : ScrollUnit.Item);
            var propScrollUnit = typeof(VirtualizingPanel).GetField("ScrollUnitProperty", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            if (propScrollUnit == null)
                return false;
            var dpScrollUnit = (DependencyProperty)propScrollUnit.GetValue(null);
            var assemblyPresentationFramework = typeof(Window).Assembly;
            var typeScrollUnit = assemblyPresentationFramework.GetType("System.Windows.Controls.ScrollUnit");
            if (typeScrollUnit == null)
                return false;
            var valueScrollUnit = Enum.Parse(typeScrollUnit, isEnabled ? "Pixel" : "Item");
            ctl.SetValue(dpScrollUnit, valueScrollUnit);
            return true;
        }
        private static bool TrySetIsPixelBased (DependencyObject ctl, bool isEnabled)
        {
            // .NET 4.0: ctl.IsPixelBased = isEnabled;
            var propIsPixelBased = ctl.GetType().GetProperty("IsPixelBased", BindingFlags.NonPublic | BindingFlags.Instance);
            if (propIsPixelBased == null)
                return false;
            propIsPixelBased.SetValue(ctl, isEnabled, null);
            return true;
        }
    }
