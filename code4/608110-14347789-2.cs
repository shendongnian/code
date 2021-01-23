    public class MyUserControl
    {
       public event System.EventHandler LinkButtonClicked;
    
    
       //add handler for your LinkButton
       protected void LinkButton1_Clicked(object sender, EventArgs e)
       {
          //Raise your custom event here that can be handled in any page that use your control
          LinkButtonClicked(sender, e);
       }
    }
