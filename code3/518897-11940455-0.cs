            private void ddlState_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(this.ddlState.SelectedValue))
                {
                    this.ddlCounty.DataSource = new List<LookupService.County>();
                }
                else
                {
                    var counties = LookupProxy.GetCounties(this.ddlState.SelectedValue).OrderBy(x => x.Name).ToList();
                    this.ddlCounty.DataSource = counties;
                }
    
                this.ddlCounty.Items.Clear();
                this.ddlCounty.Items.Add(new ListItem());
                this.ddlCounty.DataBind();
            }
