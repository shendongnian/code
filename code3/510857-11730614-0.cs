    public partial class ucBuyerList : System.Web.UI.UserControl
    {
        public delegate void BuyerSelectedEventHandler(object sender, EventArgs e);
    
        public event BuyerSelectedEventHandler BuyerSelected;
    
        public string Name;
        public string AUID;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            //Select the first buyer in the list when the user control loads
            
            if (!IsPostBack)
            {
                lbBuyerList.SelectedIndex = 0;
            }
        }
    
        private void OnBuyerSelected(EventArgs e)
        {
            BuyerSelectedEventHandler handler = BuyerSelected;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    
        protected void lbBuyerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Name = lbBuyerList.SelectedItem.Text;
            AUID = lbBuyerList.SelectedItem.Value;
            OnBuyerSelected(e);
        }
    }
