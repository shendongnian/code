    // declare this
    public static class ExtensionMethods
    {
       private static Action EmptyDelegate = delegate() { };
 
       public static void Refresh(this UIElement uiElement)
       {
          uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
       }
    }
    
    // the loop
    for (int i = 0; i < 2; i++)
        {
            updateTextBox(i.ToString());
            PrintDialog dialog = new PrintDialog();
            dialog.PrintVisual(this.canvas, "");
        }
    }
    
    // update this method
    private void updateTextBox(string text)
    {
        txtTextBox.Text = text;
        txtTextBox.Refresh();
        Thread.Sleep(500);
    }
