    for (int i=0;i<dataGrid1.Items.Count;i++) 
    {
       
        // get control which represents the data
        var control = dataGrid1.ItemContainerGenerator.ContainerFromItem(dataGrid1.Items[i]);
        DependencyObject obj = control
        
        // inside that control there is somewhere the ListBox so run down the visualtree till you find the damn ListBox
        for(;!(obj is ListBox);
            obj = VisualTreeHelper.GetChild(obj, 0));
      
        ListBox listBox = obj as ListBox;
        if(listBox != null)
        {
          // get the selected values from ListBox
          var selectedItems = listBox.SelectedItems;
          foreach(var selectedItem in selecteditems)
          {
             Console.WriteLine("I am a selected item: " + selectedItem.ToString());
          }
        } 
    }
