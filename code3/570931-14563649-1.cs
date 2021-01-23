    //-----------------------------------------------------------------------------------
                public static T FindVisualChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                    {
                        var child = VisualTreeHelper.GetChild(parent, i);
                        string controlName = child.GetValue(Control.NameProperty) as string;
                        if (controlName == name)
                        {
                            return child as T;
                        }
                        else
                        {
                            T result = FindVisualChildByName<T>(child, name);
                            if (result != null)
                                return result;
                        }
                    }
                    return null;
                }
    
                //Here FlipView Loaded Event 
                private void ItemDetailPageflipView_Loaded(object sender, RoutedEventArgs e)
                {
                    WebView ItemDetailPageWebView = FindVisualChildByName<WebView>(this.flipView, "ItemDetailPageWebView");
                    ItemDetailPageWebView.Navigate(new Uri("http://www.google.com"));
                }
    
            //-----------------------------------------------------------------------------------
