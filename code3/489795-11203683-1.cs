    private Point _startPoint;
    private static readonly string _dropIdentifier = "dropIdentifier";
    private void listBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      // The initial mouse position
      _startPoint = e.GetPosition(null);
    }
    private void listBox_PreviewMouseMove(object sender, MouseEventArgs e)
    {
      // Get the current mouse position
      Point mousePos = e.GetPosition(null);
      Vector diff = _startPoint - mousePos;
      if (e.LeftButton == MouseButtonState.Pressed &&
          (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
          Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
      {
        // Get the dragged ListBoxItem
        var listBox = sender as ListBox;
        var listBoxItem = listBox.SelectedItem;
        // Initialize the drag & drop operation
        DataObject dragData = new DataObject(_dropIdentifier, listBoxItem);
        DragDrop.DoDragDrop(listBox, dragData, DragDropEffects.Move);
      } 
    }
    private void canvasImage_Drop(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(_dropIdentifier))
      {
        var item = e.Data.GetData(_dropIdentifier) as ListBoxItem;
        DropOnCanvas(sender as Canvas, item);
      }
    }
    private void canvasImage_DragEnter(object sender, DragEventArgs e)
    {
      if (!e.Data.GetDataPresent(_dropIdentifier) ||
        sender == e.Source)
      {
        e.Effects = DragDropEffects.None;
      }
    }
    public void DropOnCanvas(Canvas targetCanvas, ListBoxItem item)
    {
      // do your stuff here ...
      int textHeight = 20;
      var text = new TextBlock() { Text = item.Content.ToString(), Height = textHeight };
      Canvas.SetTop(text, targetCanvas.Children.Count * textHeight);
      targetCanvas.Children.Add(text);
    }
