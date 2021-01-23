        using System.Windows;
        using System.Windows.Controls;
        namespace AndroidCtrlUI.XTools.Behaviors
        {
            ///<summary>
            /// TreeItemAttach 
            ///<para/> TreeViewItem
            ///</summary>
            public sealed class TreeItemAttach
            {
                #region BringIntoView
                ///<summary>
                /// DependencyProperty
                ///</summary>
                public static readonly DependencyProperty BringIntoViewProperty = DependencyProperty.RegisterAttached("BringIntoView", typeof(bool), typeof(TreeItemAttach), new UIPropertyMetadata(false, (s, e) =>
                {
                    if ((bool)e.NewValue != (bool)e.OldValue && s is TreeViewItem t)
                    {
                        if ((bool)e.NewValue)
                        {
                            t.Selected += BringIntoView;
                        }
                        else
                        {
                            t.Selected -= BringIntoView;
                        }
                    }
                }));
                ///<summary>
                /// Get
                ///</summary>
                ///<param name="target">DependencyObject</param>
                ///<returns>ICommand</returns>
                public static bool GetBringIntoView(DependencyObject target)
                {
                    return (bool)target.GetValue(BringIntoViewProperty);
                }
                ///<summary>
                /// Set
                ///</summary>
                ///<param name="target">DependencyObject</param>
                ///<param name="value">ICommand</param>
                public static void SetBringIntoView(DependencyObject target, bool value)
                {
                    target.SetValue(BringIntoViewProperty, value);
                }
                private static void BringIntoView(object sender, RoutedEventArgs e)
                {
                    if (e.Source is TreeViewItem s)
                    {
                        if (s.IsExpanded && s.Items.Count > 0)
                        {
                            double h = s.ActualHeight / TreeWalker(s);
                            if (h == 0)
                            {
                                h = s.ActualHeight;
                            }
                            s.BringIntoView(new Rect(0, h * -1, s.ActualWidth, h * 2.5));
                            return;
                        }
                        s.BringIntoView(new Rect(0, s.ActualHeight * -1, s.ActualWidth, s.ActualHeight * 2.5));
                    }
                }
                private static long TreeWalker(TreeViewItem item)
                {
                    long c = item.Items.Count;
                    foreach (object i in item.Items)
                    {
                        if (i != null && item.ItemContainerGenerator.ContainerFromItem(i) is TreeViewItem t && t.IsExpanded && t.Items.Count > 0)
                        {
                            c += TreeWalker(t);
                        }
                    }
                    return c;
                }
                #endregion
            }
        }
 
