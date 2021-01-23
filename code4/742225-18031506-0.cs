        comboBox1.ItemsSource = students.Select(x => x.Gender).Distinct(); 
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listView1.ItemsSource = students
                .Where(x => x.Gender == comboBox1.SelectedItem.ToString()).ToList();
        }
