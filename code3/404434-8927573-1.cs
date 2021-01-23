    public partial class _Default : System.Web.UI.Page
    {
        public List<Waypoints> waypointList;//or protected
        public IWaypointLogic waypointLogic;//or protected
    
        protected void Page_Load(object sender, EventArgs e)
        {
            waypointLogic = new WaypointLogic();
            waypointList = waypointLogic.GetWaypointsByTrackId(1);
        }
    }  
