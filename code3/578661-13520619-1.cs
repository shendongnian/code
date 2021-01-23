    private void dgStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (e.AddedItems != null && e.AddedItems.Count != 0)
                {
                    foreach (Student item in e.AddedItems)
                    {
                        Console.WriteLine(item.ID);
                    }
                }
            }
