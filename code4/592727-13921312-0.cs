    using System.Windows;
    using System.Windows.Input;
    using System.Activities.Presentation;
    using System.Windows.Media;
    
    namespace ActivityDesignerLibrary1
    {
        public partial class ActivityDesigner1
        {
            public ActivityDesigner1()
            {
                InitializeComponent();
            }
    
            protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
            {
                if (e.ClickCount == 2)
                {
                    FrameworkElement fe = e.OriginalSource as FrameworkElement;
                    if (fe != null)
                    {
                        object original = fe.DataContext;
                        ActivityDesigner baseActivityDesigner = original as ActivityDesigner;
                        if (baseActivityDesigner == null)
                        {
                            baseActivityDesigner = this.ActivityDesignerFinder((DependencyObject)e.OriginalSource);
                        }
    
                        if (baseActivityDesigner != null)
                        {
                            MessageBox.Show(baseActivityDesigner.GetHashCode().ToString());
                            e.Handled = true;
                        }
                    }
                }
            }
    
    
            private ActivityDesigner ActivityDesignerFinder(DependencyObject dependencyObject)
            {
                while (dependencyObject != null)
                {
                    if (dependencyObject is ActivityDesigner)
                    {
                        return (ActivityDesigner)dependencyObject;
                    }
    
                    dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
                }
    
                return null;
            }
        }
    }
