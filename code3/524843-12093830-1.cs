    public partial class YourPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
             ddlistCountries.SelectedIndexChanged += new EventHandler(ddlist_SelectedIndexChanged);
        } 
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!isPostBack)
            {
                PopulateCountries();
                ddlistStates.Enabled = false; // no country selected yet!
            }
        }
        
        protected void PopulateCountries()
        {
            ddlistCountries = DataAccessClass.GetCountries();
            ddlistCountries.DataBind();   
            ddlist.Items.Insert(0, "Select a country");
        }
    
        void ddlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlistCountries.SelectedIndex != 0)
            {
                 ddlistStates.DataSource = DataAccessClass.GetStates(ddlistCountries.SelectedValue);
                 ddlistStates.DataBind();
                 ddlistStates.Enabled = true;
            }
            else
            {
                ddlistStates.Items.Clear();
                ddlistStates.Enabled = false;
            }
        }
    } 
