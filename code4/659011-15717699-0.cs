    public class GridClass
    {
      private MainWindow window;
      public GridClass( MainWindow Window)
      {
         window = Window;
      }
      public Point functionFromGridClass()
      {
         Point variable = window.functionFromMainWindowClass(0, 0);
      }
    }
