    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    
    namespace SilverlightApplication3
    {
        public partial class MainPage : UserControl
        {
            public MainPage()
            {
                InitializeComponent();
            }
    
            private void btnWalkTree_Click(object sender, RoutedEventArgs e)
            {
                this.WalkChildren(this);
            }
    
            private void WalkChildren(DependencyObject depObject)
            {
                string name = String.Empty;
                FrameworkElement element = depObject as FrameworkElement;
                if (element != null)
                {
                    name = element.Name;
                }
    
                int childCount = VisualTreeHelper.GetChildrenCount(element);
                if (childCount > 0)
                {
                    for (int i = 0; i < childCount; i++)
                    {
                        this.WalkChildren(VisualTreeHelper.GetChild(element, i));
                    }
                }
            }
        }
    }
