    public partial class Child : System.Web.UI.UserControl
    {
        // here, we declare the event
        public event EventHandler OnChildEventOccurs;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            // some code ...
            List<string> results = new List<string>();
            results.Add("Item1");
            results.Add("Item2");
            // this code says: when some one is listening this event, raises this and send one List of string as parameters
            if (OnChildEventOccurs != null)
                OnChildEventOccurs(results, null);
        }
    }
