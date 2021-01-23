    public static class PanelExtension {
      public static void ScrollToPosition(this Panel p, int pos){
         using(Control c = new Control() { Parent = p, Height = 1, Top = p.ClientSize.Height + pos}){
            p.ScrollControlIntoView(c);
            c.Parent = null;
         {
      }
    }
