    protected void GridDataBind(object sender, GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow) {
    		IEnumerable list = PremiumUnitFees.PremiumAmenities.ObtainFeesForProject(IntranetUser.Current.ProjectId);
    		foreach (PremiumUnitFees.PremiumAmenities feature in list) {
    			e.Row.Cells(3).Controls.Add(new CheckBox {
    				ID = feature.Id.ToString(),
    				Text = feature.NickName,
    				Checked = PremiumUnitFees.PremiumUnitView.IsUnitPremium(feature.Id, Convert.ToInt64(DataBinder.Eval(e.Row.DataItem, "Id")))
    			});
    		}
    	}
    }
