    void rptMission_ItemDataBound(Object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            Mission row = (Mission)item.DataItem;
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                var rptActivity = (Repeater)item.FindControl("rptActivity");
                var activity = _presenter.GetActivitiesByMission(row.Id);
                var i = 0;
                foreach (Activity data in activity)
                {
                    RepeaterItem activityItem = rptActivity.Items[i];
                    var rptProject = (Repeater)activityItem.FindControl("rptProject");
                    var project = _presenter.GetProjectsByActivities(data.Id);
                    rptProject.DataSource = project;
                    rptProject.DataBind();
                    i++;
                }
                rptActivity.DataSource = activity;
                rptActivity.DataBind();
            }
        }
