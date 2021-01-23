    protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            //Linq is used to load the table to the code
            DataClassesDataContext data = new DataClassesDataContext();
            //Select all from the table
            //List<addressmap> lst = (from u in data.addressmaps select u).ToList();
            List<addressmap> lst = (from u in data.addressmaps where u.StoreLocation == TxtSearch.Text || u.StoreCity == TxtSearch.Text || u.StoreState == TxtSearch.Text || u.StoreCountry == TxtSearch.Text select u).ToList();
            //add the table contents to the javascript array so that new locations will be loaded
            foreach (addressmap item in lst)
            {
                ScriptManager.RegisterArrayDeclaration(UpdatePanel1, "infoarray", "'" + item.StoreAddress.ToString() + "'");
                ScriptManager.RegisterArrayDeclaration(UpdatePanel1, "lonarray", item.StoreLongitude.ToString());
                ScriptManager.RegisterArrayDeclaration(UpdatePanel1, "latarray", item.StoreLatitude.ToString());
                ScriptManager.RegisterArrayDeclaration(UpdatePanel1, "bounce", item.StoreBounce.ToString());
            }
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //update the update panel every 10 seconds
            UpdatePanel1.Update();
        }
