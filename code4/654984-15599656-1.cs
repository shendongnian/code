     ComboBox comboBox1 = new ComboBox();
            comboBox1.Height = 23;
            comboBox1.Width = 200;
            GroupStyle style = new GroupStyle();
            style.HeaderTemplate = (DataTemplate)this.FindResource("groupStyle");
            comboBox1.GroupStyle.Add(style);
            comboBox1.DisplayMemberPath = "Item";
            comboBox1.ItemContainerStyle = (Style)this.FindResource("comboBoxItemStyle");
            
            ObservableCollection<CategoryItem<string>> items = new ObservableCollection<CategoryItem<string>>();
            items.Add(new CategoryItem<string> { Category = "Warm Colors", Item = "Orange" });
            items.Add(new CategoryItem<string> { Category = "Warm Colors", Item = "Red" });
            items.Add(new CategoryItem<string> { Category = "Warm Colors", Item = "Pink" });
            items.Add(new CategoryItem<string> { Category = "Cool Colors", Item = "Blue" });
            items.Add(new CategoryItem<string> { Category = "Cool Colors", Item = "Purple" });
            items.Add(new CategoryItem<string> { Category = "Cool Colors", Item = "Green" });
            CollectionViewSource cvs = new CollectionViewSource();
            cvs.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            cvs.Source = items;
            Binding b = new Binding();
            b.Source = cvs;
            BindingOperations.SetBinding(
               comboBox1, ComboBox.ItemsSourceProperty, b);
