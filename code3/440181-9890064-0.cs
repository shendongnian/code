    protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostback){
            string buildingTypeSoldier = "soldier";
            var soldierBuilding = from b in dc.Buildings
                                     where b.buildingtype == buildingTypeSoldier
                                     select b.buildingname;
            ddlSoldierBuildings.DataSource =soldierBuilding;
            ddlSoldierBuildings.DataBind();
           }
        }
