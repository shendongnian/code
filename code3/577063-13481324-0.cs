    public class Button
    {
       System.Windows.Forms.ToolStripItem button;
      public MyButton(System.Windows.Forms.ToolStripItem button)
      {
        this.button = button;
      }
      public void EnableButton(bool enable)
      {
        button.Enable = enable;
      }
      //...
    }
