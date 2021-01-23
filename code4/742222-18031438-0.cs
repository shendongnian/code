    //For Combobox (You can
    private void Window_Loaded(object sender, RoutedEventArgs e)
        {           
            var AllGender = (from cat in students select cat.Gender).Distinct();
            foreach (var gender in AllGender)
            {
                comboBox1.Items.Add(gender.ToString());
            }
        }
    //For ListBox
    private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedValue = comboBox1.SelectedItem.ToString();
            var studentList = from student in students 
                              where student.Gender == selectedValue 
                              select new { Firstname = student.FirstName, LastName = student.LastName };
            listBox1.Items.Clear();
            foreach (var student in studentList)
            {
                listBox1.Items.Add(student.Firstname + " " + student.LastName);
            }
        }
