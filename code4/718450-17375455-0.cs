    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace ImageViewer    
    {
        public class ScrollViewerEx
        {
        public static double GetHOffset(ScrollViewer obj)
        {
            return (double)obj.GetValue(ScrollViewer.HorizontalOffsetProperty);
        }
        public static void SetHOffset(ScrollViewer obj, double value)
        {
            obj.SetValue(HOffsetProperty, value);
        }
        // Using a DependencyProperty as the backing store for HOffset.  This enables animation, styling, binding, etc...  
        public static readonly DependencyProperty HOffsetProperty =
            DependencyProperty.RegisterAttached("HOffset", typeof(double), typeof(ScrollViewerEx), new PropertyMetadata(new PropertyChangedCallback(OnHOffsetChanged)));
        private static void OnHOffsetChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var scroll = sender as ScrollViewer;
            scroll.ScrollToHorizontalOffset((double)e.NewValue);
        }
        public static double GetVOffset(ScrollViewer obj)
        {
            return (double)obj.GetValue(ScrollViewer.VerticalOffsetProperty);
        }
        public static void SetVOffset(ScrollViewer obj, double value)
        {
            obj.SetValue(VOffsetProperty, value);
        }
        // Using a DependencyProperty as the backing store for VOffset.  This enables animation, styling, binding, etc...  
        public static readonly DependencyProperty VOffsetProperty =
            DependencyProperty.RegisterAttached("VOffset", typeof(double), typeof(ScrollViewerEx), new PropertyMetadata(new PropertyChangedCallback(OnVOffsetChanged)));
        private static void OnVOffsetChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var scroll = sender as ScrollViewer;
            scroll.ScrollToVerticalOffset((double)e.NewValue);
        }
    }  
    }
