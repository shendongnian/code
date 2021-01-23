    public class MyButton : Button {
      private Color myColor = Color.ForestGreen;
      public MyButton() {
        base.BackColor = myColor;
      }
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public new Color BackColor {
        get { return myColor; }
        set { // do nothing 
        }
      }
    }
