     private void Insert_Click_1(object sender, RoutedEventArgs e)
            {
                // Create a new task.
                Task task = new Task()
                {
                    Title = TitleField.Text,
                    Text = TextField.Text,
                    CreationDate = DateTime.Now
                };
                /// Insert the new task in the Task table.
                dbConn.Insert(task);
                /// Retrieve the task list from the database.
                List<Task> retrievedTasks = dbConn.Table<Task>().ToList<Task>();
                /// Clear the list box that will show all the tasks.
                TaskListBox.Items.Clear();
                foreach (var t in retrievedTasks)
                {
                    TaskListBox.Items.Add(t);
                }
            }
