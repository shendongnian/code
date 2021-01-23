	using System.Windows;
	using System.Windows.Controls;
	namespace WpfApplication1
	{
		public static class ListBoxExtension
		{
			public static readonly DependencyProperty NullSelectedItemOnLostFocusProperty =
				DependencyProperty.RegisterAttached("NullSelectedItemOnLostFocus", typeof(bool), typeof(ListBoxExtension), new UIPropertyMetadata(false, OnNullSelectedItemOnLostFocusChanged));
			public static bool GetNullSelectedItemOnLostFocus(DependencyObject d)
			{
				return (bool)d.GetValue(NullSelectedItemOnLostFocusProperty);
			}
			public static void SetNullSelectedItemOnLostFocus(DependencyObject d, bool value)
			{
				d.SetValue(NullSelectedItemOnLostFocusProperty, value);
			}
			private static void OnNullSelectedItemOnLostFocusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
			{
				bool nullSelectedItemOnLostFocus = (bool)e.NewValue;
				ListBox listBox = d as ListBox;
				if (listBox != null)
				{
					if (nullSelectedItemOnLostFocus)
						listBox.LostFocus += NullSelectedItem;
					else
						listBox.LostFocus -= NullSelectedItem;
				}
			}
			public static void NullSelectedItem(object sender, RoutedEventArgs e)
			{
				ListBox listBox = sender as ListBox;
				if (listBox != null)
				{
					listBox.SelectedItem = null;
				}
			}
		}
	}
