         for (int intCount = 0; intCount < ListBox2.SelectedItems.Count; intCount++)
         {
            ListBox1.Items.Add(ListBox2.SelectedItems[intCount]);
            ListBox2.Items.Remove(ListBox2.SelectedItems[intCount]);
            //Every time remove item, reduce the index           
            intCount--;
         }     
**<<**
         for (int intCount = 0; intCount < ListBox2.SelectedItems.Count; intCount++)
         {
            ListBox2.Items.Add(ListBox1.SelectedItems[intCount]);
            ListBox1.Items.Remove(ListBox1.SelectedItems[intCount]);
            //Every time remove item, reduce the index           
            intCount--;
         } 
