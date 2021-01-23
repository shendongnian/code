     Application.Current.Dispatcher.BeginInvoke(
             DispatcherPriority.Background,
                new Action(() =>
                {
                    listBox1.ItemsSource = daoActivity.GetAll();
                    listBox1.DisplayMemberPath = "ActivityName";
                    listBox1.SelectedValuePath = "ActivityID";
                }));
