    public class mainScreen: UserControl
    {
        public int matchID { get; set; }
    }
    
    // ...
    
    mainScreen CurrentControl = (mainScreen)Page.LoadControl("mainScreen.ascx");
    CurrentControl.matchID = 2;
