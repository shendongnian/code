        private void Populate()
        {
            DataTable dtPackage = tblPackage();
            DataTable dtDetails = tblDetails();
            rptrPackage.DataSource = dtPackage;
            rptrPackage.DataBind();
            foreach (RepeaterItem item in rptrPackage.Items)
            {
                Repeater rptDetails = ((Repeater)item.FindControl("rptDetails"));
                rptDetails.DataSource = dtDetails.Select("PackageID = " + ((HiddenField)item.FindControl("hID")).Value).CopyToDataTable();
                rptDetails.DataBind();
            }
        }
