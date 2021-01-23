    for (int i = 0; i < 2; i++)
    {
      updateTextBox(i.ToString());
      this.canvas.InvalidateVisual(); // Maybe not needed in your case
    
      PrintDialog dialog = new PrintDialog();
    
      this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, (Action)delegate()
      {
         dialog.PrintVisual(this.canvas, "" + i);
      });
    }
