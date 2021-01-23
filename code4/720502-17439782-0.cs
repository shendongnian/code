    private void CurrentServiceGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (((Windows.UI.Xaml.Controls.ListViewBase)(sender)).Name == CurrentServiceGridView.Name)
                {
                    if (AllServicesGridView.SelectedItem != null)
                    {
                        AllServicesGridView.SelectionChanged -= CurrentServiceGridView_SelectionChanged;
                        AllServicesGridView.SelectedItem = null;
                        AllServicesGridView.SelectionChanged += CurrentServiceGridView_SelectionChanged;
                    }
                }
                else
                {
                    if (CurrentServiceGridView.SelectedItem != null)
                    {
                        CurrentServiceGridView.SelectionChanged -= CurrentServiceGridView_SelectionChanged;
                        CurrentServiceGridView.SelectedItem = null;
                        CurrentServiceGridView.SelectionChanged += CurrentServiceGridView_SelectionChanged;
                    }
                }
            }
