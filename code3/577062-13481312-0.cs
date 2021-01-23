    public class Button
    {
      Control button;
    
      public Button(Control button)
      {
        this.button = button;
      }
    
      public void EnableButton(bool enable)
      {
        button.Enabled = enable;
      }
    
      //...
    }
   
