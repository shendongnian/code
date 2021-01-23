    namespace The.Namespace
    {
        using System;
        using System.Linq;
        using System.Windows;   
        using System.Windows.Controls;
        using System.Windows.Input;
        /// <summary>
        /// Scroll selected item into view.
        /// </summary>
        public class ListBoxFocusBehavior : FocusBehavior<ListBox>
        {
            public static readonly DependencyProperty IsContinuousProperty = DependencyProperty.Register("IsContinuous",
                                                                             typeof(bool),
                                                                             typeof(ListBoxFocusBehavior),
                                                                             new PropertyMetadata(
                                                                                 false,
                                                                                 (d, e) => ((ListBoxFocusBehavior)d).IsContinuousScroll = (bool)e.NewValue));
            /// <summary>
            /// Gets or sets a value indicating whether this instance is continuous.
            /// </summary>
            /// <value>
            ///      <c>true</c> if this instance is continuous; otherwise, <c>false</c>.
            /// </value>
            public bool IsContinuous
            {
                get { return (bool)GetValue(IsContinuousProperty); }
                set { SetValue(IsContinuousProperty, value); }
            }
            /// <summary>
            /// Called after the behavior is attached to an AssociatedObject.
            /// </summary>
            protected override void OnAttached()
            {
                base.OnAttached();
                AssociatedObject.SelectionChanged += SelectionChanged;
                AssociatedObject.KeyDown += KeyDown;
            }
     
            /// <summary>
            /// Keys down.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="System.Windows.Input.KeyEventArgs"/> instance containing the event data.</param>
            private void KeyDown(object sender, KeyEventArgs e)
            {
                e.Handled = false;
                if (e.Key == Key.Tab && Keyboard.Modifiers == ModifierKeys.None)
                {
                   //forward tab ...
                    var idx = AssociatedObject.Items.IndexOf(AssociatedObject.SelectedItem);
                    if (idx < AssociatedObject.Items.Count-1)
                    {
                        AssociatedObject.SelectedItem = AssociatedObject.Items[idx + 1];
                        e.Handled = true;
                    }
                }
                if (e.Key == Key.Tab && (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                {
                    //back tab.
                    var idx = AssociatedObject.Items.IndexOf(AssociatedObject.SelectedItem);
                    if (idx > 0)
                    {
                        AssociatedObject.SelectedItem = AssociatedObject.Items[idx - 1];
                        e.Handled = true;
                    }
     
                }
            }
     
     
     
            /// <summary>
            /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
            /// </summary>
            protected override void OnDetaching()
            {
                base.OnDetaching();
                AssociatedObject.SelectionChanged -= SelectionChanged;
                AssociatedObject.KeyDown -= KeyDown;
            }
     
            /// <summary>
            /// Gots the focus.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
            private void GotFocus(object sender, RoutedEventArgs e)
            {
                if (AssociatedObject.SelectedItem == null && AssociatedObject.Items.Any())
                {
                    AssociatedObject.SelectedItem = AssociatedObject.Items.First();
                }
            }
     
            /// <summary>
            /// Selections the changed.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
            private void SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (AssociatedObject.SelectedItem == null) return;
                AssociatedObject.UpdateLayout();
     
                //have to, otherwise the listbox will probably not focus.
                Action setFocus = () =>
                                      {
                                          AssociatedObject.UpdateLayout();                                     
                                          AssociatedObject.ScrollIntoView(AssociatedObject.SelectedItem);
                                          //ensure that if the container did not exist yet (virtualized), it gets created.
                                          AssociatedObject.UpdateLayout();   
                                          var container =
                                             AssociatedObject.ItemContainerGenerator.ContainerFromItem(
                                                 AssociatedObject.SelectedItem) as Control;
                                          if (container != null)
                                          {
                                              container.Focus();
                                          }
     
                                      };
                AssociatedObject.Dispatcher.BeginInvoke(setFocus);
            }
        }
    }
