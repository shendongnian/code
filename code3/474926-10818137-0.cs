        protected void ldsCampaigns_Updated(object sender, LinqDataSourceStatusEventArgs e)
        {
            using (DashboardDataContext c = new DashboardDataContext())
            {
                Label Label3 = gvManager.Rows[gvManager.EditIndex].FindControl("Label4") as Label;
                List<CMSCampaigns> change = c.CMSCampaigns.Where(s => s.ContentID == Convert.ToInt16(Label3.Text)).ToList();
                DropDownList DropDownList2 = gvDashboardManager.Rows[gvDashboardManager.EditIndex].FindControl("DropDownList2") as DropDownList;
                change[0].DataColumn = DropDownList2.SelectedValue.ToString();
                c.SubmitChanges();
            }
        }
