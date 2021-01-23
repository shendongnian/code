     header.MouseRightButtonDown += new MousebuttonEventHandler(rightClickSelection);
     
     private void rightclickSelection(object sender, MouseButtonEventArgs e) {
          TreeViewItem clickedParent = (sender as TextBlock).Parent as TreeViewItem;
          clickedParent.IsSelected = true;
          clickedParent.UpdateLayout();
     }
