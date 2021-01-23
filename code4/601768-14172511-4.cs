        private void testButton1_Click(object sender, RoutedEventArgs e)
        {
            // Creating a dynamic dictionary.
            var dd = new BindableDynamicDictionary();
            //access like any dictionary
            dd["Age"] = 32;
            //or as a dynamic
            dynamic person = dd;
            // Adding new dynamic properties.  
            // The TrySetMember method is called.
            person.FirstName = "Alan";
            person.LastName = "Evans";
            //hacky for short example, should have a view model and use datacontext
            var collection = new ObservableCollection<object>();
            collection.Add(person);
            dataGrid1.ItemsSource = collection;
        }
