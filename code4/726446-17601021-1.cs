            Binding binding = new Binding();
            binding.Source = messages;
            listView.SetBinding(ItemsControl.ItemsSourceProperty, binding);
            MainGrid.Children.Add(listView);
            MainGrid1.ItemsSource = messages;
