    private void listBox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Submit clicked Entry
             if(sender is ListBox)
             {
                var listBoxRef = sender as ListBox;
                ...
                if (listBoxRef.SelectedItem != null)
                .....
                ....
          }
        }
