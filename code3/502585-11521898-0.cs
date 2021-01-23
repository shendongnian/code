    public partial class Entscheidungen : System.Web.UI.Page
    {
        private string _address;
        protected void Page_Load(object sender, EventArgs e)
        {
             bt.Command += new CommandEventHandler(bt_Command);
        }
        void bt_Command(object sender, CommandEventArgs e)
        {
             _address = Service.GetAddressMarker(string lat, string lng)
        }
        ....
    }
