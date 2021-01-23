    public partial class _Default : System.Web.UI.Page
    {
        public List<Waypoints> waypointList;
        public IWaypointLogic waypointLogic;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            waypointLogic = new WaypointLogic();
            waypointList = waypointLogic.GetWaypointsByTrackId(1);
        }
    }  
