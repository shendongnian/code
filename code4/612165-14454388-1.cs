     for (int i = 0; i < myDataGrid.Columns.Count; i++)
                        {
                            var childStackPanel = new StackPanel { Orientation = Orientation.Horizontal };
    
                            var myTextBlock = new TextBlock { Text = myDataGrid.Columns[i].Header + " : " };
    
                            var myTextBox = new TextBox { Width = 200 };
    
                            Type myType = typeof(Text);
                            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
                            myTextBox.SetBinding(TextBox.TextProperty,
                                                  new Binding("SelectedItem." + props[i].Name) { ElementName = "myDataGrid" });
                            childStackPanel.Children.Add(myTextBlock);
                            childStackPanel.Children.Add(myTextBox);
                            myStackPanel.Children.Add(childStackPanel);
                        }
