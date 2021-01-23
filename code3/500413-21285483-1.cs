    if (!string.IsNullOrEmpty(Request.QueryString["type"]) && Request.QueryString["type"].ToUpper() == "TRUE")
                {
                    foreach (ListItem item in rdoList.Items)
                    {
                        if (item.Text == "External")
                        {
                            item.Enabled = false;
                            item.Attributes.Add("style", "color:#999;");
                            break;
                        }
                    }
                }
