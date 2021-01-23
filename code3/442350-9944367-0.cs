    protected void ddlSoldiers_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["userRole"] == null || Session["userRole"].Equals("admin"))
        {
            Response.Redirect("Login.aspx");
        }
        int userid = Convert.ToInt32(Session["userid"]);
        if (string.IsNullOrEmpty(ddlSoldiers.SelectedValue))
        {
            var varTroopType = dc.Troops.Single(t => t.troopid == 1).type;
            string troopType = Convert.ToString(varTroopType);
            var varBuildingId = dc.Buildings.Single(b => b.soldierType == troopType).buildingid;
            int buildingId = Convert.ToInt32(varBuildingId);
            var varNumberOfBuildings =
            dc.Towns.Single(t => (t.buildingid == buildingId) && (t.userid == userid)).number;
            int numberOfBuildings = Convert.ToInt32(varNumberOfBuildings);
            for (int i = 1; i < numberOfBuildings + 1; i++)
            {
                ddlSoldierNumber.Items.Add(i.ToString());
            }
        }
        else
        {
            ddlSoldierNumber.Items.Clear();
            string troopType = ddlSoldiers.SelectedItem.Text;
            var varBuildingId = dc.Buildings.Single(b => b.soldierType == troopType).buildingid;
            int buildingId = Convert.ToInt32(varBuildingId);
            var varNumberOfBuildings =
                dc.Towns.Single(t => (t.buildingid == buildingId) && (t.userid == userid)).number;
            int numberOfBuildings = Convert.ToInt32(varNumberOfBuildings);
            for (int i = 1; i < numberOfBuildings + 1; i++)
            {
                ddlSoldierNumber.Items.Add(i.ToString());
            }
        }
    }
