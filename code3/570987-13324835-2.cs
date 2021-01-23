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
    namespace WpfControlLibrary1  
    {
        /// <summary>
        /// Interaction logic for UserControl1.xaml
        /// </summary>
        public partial class UserControl1 : UserControl
        {
            public UserControl1()
            {
                InitializeComponent();
            }
            public Point  SetChildLocation
            {
                get
                {
                    return new Point(Canvas.GetLeft(userControl21), Canvas.GetTop(userControl21));
                }
                set
                {
                    Canvas.SetLeft(userControl21, value.X);
                    Canvas.SetTop(userControl21, value.Y);
                }
            }
            public Size SetChildSize
            {
                get
                {
                    return new Size(userControl21.ActualWidth, userControl21.ActualHeight);
                }
                set
                {
                    userControl21.Width = value.Width;
                    userControl21.Height = value.Height;
                }
            }
        }
    }
