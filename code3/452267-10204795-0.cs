    public partial class AirportParking : Form
    {
      .....
      .....
    
      protected override void OnClosing(...)
      {
           myTimer.Dispose();
      }
    }
