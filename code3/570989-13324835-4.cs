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
        /// Interaction logic for UserControl2.xaml
        /// </summary>
        public partial class UserControl2 : UserControl
        {
            public UserControl2()
            {
                InitializeComponent();
            }
            private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                rect.Width = e.NewSize.Width;
                rect.Height = e.NewSize.Height;
            }
        }
    }
