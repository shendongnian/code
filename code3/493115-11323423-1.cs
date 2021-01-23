     int itemsCount = this.TrackingView1.Items.Count;
     List<string> myList = new  List<string>();
     for (int i = 0; i < itemsCount; i++)
     {
                ListBoxItem item = (ListBoxItem)this.TrackingView1.ItemContainerGenerator.ContainerFromIndex(i);
                CheckBox tagregCheckBox = FindFirstElementInVisualTree<CheckBox>(item);
                if((bool)tagregCheckBox.IsChecked)                
                  myList.Add(tagregCheckBox.Content.ToString());
     }
 
