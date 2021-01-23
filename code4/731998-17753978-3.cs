    public static class PanelExtension {
       public static void ScrollToBottom(this Panel p){
          using (Control c = new Control() { Parent = p, Dock = DockStyle.Bottom })
          {
             p.ScrollControlIntoView(c);
             c.Parent = null;
          }
       }
    }
    //Use the code
    yourPanel.ScrollToBottom();
