     ComboBox comboBox1 = new ComboBox();
     GroupStyle style = new GroupStyle();
     style.HeaderTemplate = (DataTemplate)this.FindResource("groupStyle");
     comboBox1.GroupStyle.Add(style);
     comboBox1.DisplayMemberPath = "Item";
     // Here is what you are looking for
     comboBox1.ItemContainerStyle = (Style)this.FindResource("comboBoxItemStyle");
            
     ObservableCollection<CategoryItem<string>> items = new ObservableCollection<CategoryItem<string>>();
     CollectionViewSource cvs = new CollectionViewSource();
     cvs.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
     cvs.Source = items;
     Binding b = new Binding();
     b.Source = cvs;
     BindingOperations.SetBinding(
               comboBox1, ComboBox.ItemsSourceProperty, b);
