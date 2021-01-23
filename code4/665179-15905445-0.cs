    public sealed class GroupBoxCloseBehavior : DependencyObject
    {
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(GroupBoxCloseBehavior), new PropertyMetadata(false, OnIsEnabledChanged));
        public static bool GetIsEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnabledProperty);
        }
        public static void SetIsEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnabledProperty, value);
        }
        private static void OnIsEnabledChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            GroupBox parent = obj as GroupBox;
            if (parent == null)
            {
                return;//Do nothing, or throw an exception depending on your preference
            }
            if (parent.IsLoaded)
            {
                MultiBinding mb = new MultiBinding();
                mb.Converter = new MultiVisibilityToVisibilityConverter();
                if ((bool)e.NewValue)
                {
                    foreach (CheckBox child in FindVisualChildren<CheckBox>(parent))
                    {
                        mb.Bindings.Add(new Binding("Visibility") { Mode = BindingMode.OneWay, Source = child });
                    }
                    BindingOperations.SetBinding(parent, UIElement.VisibilityProperty, mb);
                }
                else
                {
                    BindingOperations.ClearBinding(parent, UIElement.VisibilityProperty);
                }
            }
            else
            {
                parent.Loaded += (sender, eventArgs) =>
                {
                    MultiBinding mb = new MultiBinding();
                    mb.Converter = new MultiVisibilityToVisibilityConverter();
                    if ((bool)e.NewValue)
                    {
                        foreach (CheckBox child in FindVisualChildren<CheckBox>(parent))
                        {
                            mb.Bindings.Add(new Binding("Visibility") { Mode = BindingMode.OneWay, Source = child });
                        }
                        BindingOperations.SetBinding(parent, UIElement.VisibilityProperty, mb);
                    }
                    else
                    {
                        BindingOperations.ClearBinding(parent, UIElement.VisibilityProperty);
                    }
                };
            }
        }
        private sealed class MultiVisibilityToVisibilityConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return values.OfType<Visibility>().Any(vis => vis != Visibility.Collapsed) ? Visibility.Visible : Visibility.Collapsed;
            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
    <StackPanel>
        <GroupBox Header="GroupBox" cl2:GroupBoxCloseBehavior.IsEnabled="True">
            <StackPanel>
                <CheckBox x:Name="CheckOne" Content="CheckBox One"/>
                <CheckBox x:Name="CheckTwo" Content="CheckBox Two"/>
            </StackPanel>
        </GroupBox>
        <StackPanel>
            <Button Content="Hide One" Click="Button_Click_1"/>
            <Button Content="Hide Two" Click="Button_Click_2"/>
        </StackPanel>
    </StackPanel>
