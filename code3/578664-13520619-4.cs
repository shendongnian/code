    private void ClassA_Click(object sender, RoutedEventArgs e)
            {
                if (dgStudents.SelectedItems != null && dgStudents.SelectedItems.Count != 0)
                {
                    foreach (Student item in dgStudents.SelectedItems)
                    {
                        item.ClassName = "ClassA";
                    }
                    dgStudents.Items.Refresh();
                }
            }
    
            private void ClassB_Click(object sender, RoutedEventArgs e)
            {
                if (dgStudents.SelectedItems != null && dgStudents.SelectedItems.Count != 0)
                {
                    foreach (Student item in dgStudents.SelectedItems)
                    {
                        item.ClassName = "ClassB";
                    }
                    dgStudents.Items.Refresh();
                }
            }
