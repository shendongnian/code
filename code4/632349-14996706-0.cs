    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
    
      StackPanel rootItem = e.OriginalSource.Ancestors()
                                            .OfType<StackPanel>()
                                            .Where(i => i.Name == "sp");
    
      int index = listPicker1.ItemContainerGenerator.IndexFromContainer(rootItem);
    }
