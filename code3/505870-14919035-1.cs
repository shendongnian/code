    private void List_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (myListBox.SelectedItem != null)
            {
                ListBox parent = (ListBox)sender;
                myModel data = parent.SelectedItem as myModel;
                if (data != null)
                {
                    DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
                }
            }
        }
        private void Square_Drop(object sender, DragEventArgs e)
        {
            MyModel data = e.Data.GetData(typeof(MyModel)) as MyModel;
            TextBlock tb = sender as TextBlock;
            tb.DataContext = data;
            //Add any database update code here
            refreshInterface();
        }
