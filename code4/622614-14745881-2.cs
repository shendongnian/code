                try
                {
                    SPWeb web = SPContext.Current.Web;
                    SPSiteDataQuery query = new SPSiteDataQuery();
    
                    switch (DropDownListNewsFeed.SelectedItem.Value)
                    {
                        case "ALL":
                            query.Lists = "<Lists>" +
                            "<List ID=" + web.Lists.TryGetList("Staff News").ID.ToString() + " />" +
                            "<List ID=" + web.Lists.TryGetList("Company News").ID.ToString() + " />" +
                            "<List ID=" + web.Lists.TryGetList("Management News").ID.ToString() + " />" +
                            "</Lists>";
                            break;
                        case "Staff News":
                            query.Lists = "<Lists><List ID=" + web.Lists.TryGetList("Staff News").ID.ToString() + " /></Lists>";
                            break;
                        case "Management News":
                            query.Lists = "<Lists><List ID=" + web.Lists.TryGetList("Management News").ID.ToString() + " /></Lists>";
                            break;
                        case "Company News":
                            query.Lists = "<Lists><List ID=" + web.Lists.TryGetList("Company News").ID.ToString() + " /></Lists>";
                            break;
                    }
    
                    query.ViewFields = "<FieldRef Name=\"Title\" /><FieldRef Name=\"Date1\" Nullable=\"TRUE\"/>";
                    query.Query = "<OrderBy><FieldRef Name='Modified' Ascending='FALSE'></FieldRef></OrderBy>";
                    query.Webs = "<Webs Scope=\"SiteCollection\" />";
    
                    query.RowLimit = 10;
    
                    DataTable dt = web.GetSiteData(query);
                    DataView dv = new DataView(dt);
    
                    GridViewNewsFeed.DataSource = dv;
                    GridViewNewsFeed.DataBind();
                }
                catch (Exception x)
                {
                    LabelException.Text = x.Message;
                }
