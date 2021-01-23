    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //only call initialise during initial page load.
                initialise();
            }
        }
    
        protected void initialise()
        {
            //add some items to the list
            Listbox1.Items.Add("Something1");
            Listbox1.Items.Add("Something2");
            Listbox1.Items.Add("Something3");
            Listbox1.Items.Add("Something4");
            Listbox1.SelectedIndex = 0; //select the first item in the list, or whatever
        }
    
        protected void lstArtiesten_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtArtName.Text = Listbox1.SelectedItem.Text;
        }
