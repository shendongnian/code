    protected override void OnDrop(DragEventArgs e)
    {
      var data = e.Data.GetData(DataFormats.Text);
      var dragSource = e.Data.GetData("DragSource");
      ...
    }
