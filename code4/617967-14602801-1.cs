    public MainWindow()
    {
      InitializeComponent();
      myDataGrid.ItemContainerGenerator.StatusChanged += onItemContainerGeneratorStatusChanged;
    }
    private void onItemContainerGeneratorStatusChanged(object sender, EventArgs e)
    {
      if (((ItemContainerGenerator)sender).Status == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
      {
        Button btn = GetVisualChild<Button>(myDataGrid);
        if (btn != null)
        {
          var row = myDataGrid.ItemContainerGenerator.ContainerFromIndex(0);
          if (row != null) btn.Width = ((DataGridRow)row).ActualHeight;
        }
      }
    }
    public T GetVisualChild<T>(Visual parent) where T : Visual
    {
      T child = default(T);
      int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
      for (int i = 0; i < numVisuals; i++)
      {
        Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
        child = v as T;
        if (child == null) child = GetVisualChild<T>(v);
        if (child != null) break;
      }
      return child;
    }
