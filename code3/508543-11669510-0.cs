    public class MyRibbon : Ribbon {
      public bool DisableMouseWheel { get; set; }
      protected override void OnMouseWheel(MouseEventArgs e) {
        if (!this.DisableMouseWheel) {
          base.OnMouseWheel(e);
        }
      }
    }
