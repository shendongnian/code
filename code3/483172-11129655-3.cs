    public class MyPanel : Panel {
      private List<PanelItem> panelItems = new List<PanelItem>();
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
      public List<PanelItem> PanelItems {
        get { return panelItems; }
      }
    }
