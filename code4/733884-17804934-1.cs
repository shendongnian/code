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
    using System.ComponentModel;
    namespace DesignPerformanceViewer.Controls
    {
        /// <summary>
        /// Interaction logic for BooleanImage.xaml
        /// </summary>
        public partial class BooleanImage : UserControl
        {
            private static readonly DependencyProperty TrueSourceProperty = DependencyProperty.Register("TrueSource", typeof(ImageSource), typeof(BooleanImage));
            private static readonly DependencyProperty TrueToolTipProperty = DependencyProperty.Register("TrueToolTip", typeof(string), typeof(BooleanImage));
            private static readonly DependencyProperty FalseSourceProperty = DependencyProperty.Register("FalseSource", typeof(ImageSource), typeof(BooleanImage));
            private static readonly DependencyProperty FalseToolTipProperty = DependencyProperty.Register("FalseToolTip", typeof(string), typeof(BooleanImage));
            private static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(bool), typeof(BooleanImage),
                new PropertyMetadata(false, new PropertyChangedCallback(OnValuePropertyChanged), new CoerceValueCallback(OnValueCoerceValueCallback)),
                new ValidateValueCallback(OnValueValidateValueCallback));
        
            public ImageSource TrueSource {  get { return (ImageSource)GetValue(TrueSourceProperty); } 
                set 
                { 
                    SetValue(TrueSourceProperty, value);
                } 
            }
            public ImageSource FalseSource { get { return (ImageSource)GetValue(FalseSourceProperty); } set { SetValue(FalseSourceProperty, value); } }
            public string TrueToolTip { get { return (string)GetValue(TrueToolTipProperty); } set { SetValue(TrueToolTipProperty, value); } }
            public string FalseToolTip { get { return (string)GetValue(FalseToolTipProperty); } set { SetValue(FalseToolTipProperty, value); } }
            public bool Value 
            { 
                get { return (bool)GetValue(ValueProperty); } 
                set 
                { 
                    SetValue(ValueProperty, value);
                } 
            }
            public BooleanImage()
            {
                InitializeComponent();
            }
            
            private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var self = (BooleanImage) d;
                var newValue = (bool) e.NewValue;
                self.image.Source = newValue ? self.TrueSource : self.FalseSource;
                self.ToolTip = newValue ? self.TrueToolTip : self.FalseToolTip;
            }       
            private static object OnValueCoerceValueCallback(DependencyObject d, object baseValue)
            {
                if (!(baseValue is bool))
                {
                    return false;
                }
                var boolValue = (bool) baseValue;
                var self = (BooleanImage)d;
                self.image.Source = boolValue ? self.TrueSource : self.FalseSource;
                self.ToolTip = boolValue ? self.TrueToolTip : self.FalseToolTip;
                return boolValue;
            }
            private static bool OnValueValidateValueCallback(object value)
            {
                return true;
            }
        }
    }
