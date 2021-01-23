     /// <summary>
     /// This is a template method to show that something occurs when you lose focus on the TreeViewItem
     /// </summary>
     /// <param name="sender">TreeViewItem</param>
     /// <param name="e">Routed Event arguments</param>
     public void treeView_FocusLoser(object sender, RoutedEventArgs e) {
          MessageBox.Show("Argg!");
     }
