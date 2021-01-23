     class Example
        {
            public int id { get; set; }
            public string Name { get; set; }
        }
        private void SetupListBox()
        {
            List<Example> lst = new List<Example>();
            lst.Add(new Example { id = 1, Name = "First Item" });
            lst.Add(new Example { id = 2, Name = "Second Item" });
            lst.Add(new Example { id = 3, Name = "Third Item" });
            listBox1.ItemsSource = lst;
            //This is what will be displayed
            listBox1.DisplayMemberPath = "Name";
            //This is what will set the selected value to the property you want
            listBox1.SelectedValuePath = "id";
        }
        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Get the selected Items id property
            int selectedItemsId = (int)listBox1.SelectedValue;
        }
