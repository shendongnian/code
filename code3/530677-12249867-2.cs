            rpt.DataBind();
            foreach (RepeaterItem ri in rpt.Items)
            {
                if (ri.ItemType == ListItemType.Item || ri.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton lnkButton1 = (LinkButton)ri.FindControl("lnkButton1");
                    ScriptManager1.RegisterAsyncPostBackControl(lnkButton1);
                }
            }
