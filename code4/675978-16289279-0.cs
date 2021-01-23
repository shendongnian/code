    if (!Page.IsPostBack)
                {
                    ServiceListRepeater.DataSource = DatabaseHelper.GetSummaryOfActiveServices();
                    ServiceListRepeater.DataBind();
                    ServiceDetailsRepeater.DataSource = DatabaseHelper.GetSummaryOfActiveServices();
                    ServiceDetailsRepeater.DataBind();
                }
         protected void ServiceDetailsRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                RepeaterItem item = e.Item;
                if ((item.ItemType == ListItemType.Item) ||(item.ItemType == ListItemType.AlternatingItem))
                {
                    HiddenField service_id = (HiddenField)item.FindControl("service_id");
                    Repeater service_features = (Repeater)item.FindControl("ServiceFeatureRepeater");
                    service_features.DataSource = DatabaseHelper.GetFeatureSummary(int.Parse(service_id.Value.ToString()));
                    service_features.DataBind();
                    Repeater service_charges =(Repeater)item.FindControl("ServiceChargeRepeater");
                    service_charges.DataSource = DatabaseHelper.GetChargeSummary(int.Parse(service_id.Value.ToString()));
                    service_charges.DataBind();
                }
            }
