    public class ImageButton : Button
    {
       public ImageButton()
       {
       	  // Set default properties.
          this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.FlatAppearance.BorderSize = 0;
       }
    
       protected override bool ShowFocusCues
       {
          get  { return false; }
       }
    }
    
