    public void setMessage(DependencyObject parent)
            {
                if (parent == null)
                {
                    return;
                }
    
    
                int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < childrenCount; i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                    var frameworkElement = child as FrameworkElement;
                    
                    if (frameworkElement != null && frameworkElement is WatermarkTextBox/*Type of element that you need*/)
                    {
                        (frameworkElement as WatermarkTextBox).Text = message;/*Value that you need*/
                        break;
    
                    }else
                        if (frameworkElement != null)
                        {
                            int CountInChildren = VisualTreeHelper.GetChildrenCount(frameworkElement);
                            for (int z = 0; z < CountInChildren; z++)
                            {
                                DependencyObject child1 = VisualTreeHelper.GetChild(frameworkElement, z);
                                setMessage(frameworkElement);
                            }
                        }
    
                }
            }
