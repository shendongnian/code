    private void theTree_MouseUp(object sender, MouseButtonEventArgs e) {
      var clickedItem = e.OriginalSource as FrameworkElement;
      if (clickedItem == null)
        return;
      var chartNode = clickedItem.DataContext as OrgChartNodeViewModel;
      if (chartNode != null)
        Debug.WriteLine(chartNode.Position.Title);
    }
