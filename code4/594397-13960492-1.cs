    namespace WebApplication2
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                var colours = new Dictionary<string, string>
                {
                    {"1x", "Green"},
                    {"2x", "Red"},
                    {"3y", "Blue"},
                    {"4y", "Black"}
                }.ToList();
            
                cmbColour.DataSource = colours;
                List<KeyValuePair<string, string>> l1 = new List<KeyValuePair<string, string>>();
                l1 = (List<KeyValuePair<string, string>>)cmbColour.DataSource;
            }
        }
    }
