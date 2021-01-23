        protected void Get_carte(object sender, CommandEventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            ViewState["liactive"] = lnk.UniqueID.ToString().Substring(0, lnk.UniqueID.ToString().Length - 4);
            lbl_carte.Text = lnk.UniqueID + " " + e.CommandArgument.ToString();
            foreach (RepeaterItem rI in Repeater1.Items)
            {
                if (rI.ItemType == ListItemType.Item || rI.ItemType == ListItemType.AlternatingItem)
                {
                    string liactiv = "";
                    if (ViewState["liactive"] != null)
                        liactiv = ViewState["liactive"].ToString();
                    var li = (HtmlControl)rI.FindControl("li");
                    if (li.UniqueID.ToString().Substring(0, li.UniqueID.ToString().Length - 3) == liactiv) //Adjust your condition
                        li.Attributes.Add("class", "active");
                    else
                        li.Attributes.Remove("class");
                }
            }
        }
