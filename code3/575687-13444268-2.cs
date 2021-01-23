    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    namespace WpfApplication1
    {
   
        public class CustomControl2 : System.Windows.Controls.Primitives.ToggleButton 
        {
            public static readonly DependencyProperty myFillColorProperty = DependencyProperty.Register("myFillColor",typeof(SolidColorBrush),typeof(System.Windows.Controls.Primitives.ToggleButton));    
            static CustomControl2()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl2), new FrameworkPropertyMetadata(typeof(CustomControl2)));
            }
            public SolidColorBrush myFillColor
            {
                get { return (SolidColorBrush)GetValue(myFillColorProperty); }
                set { SetValue(myFillColorProperty, value); }
            }
        }
    }
