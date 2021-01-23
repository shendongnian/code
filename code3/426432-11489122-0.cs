    protected void rpTransactions_OnItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var dataItem = e.Item.DataItem;
                string typeName;
                if (dataItem == null)
                {
                    typeName = ViewState["typeName"].ToString();
                }
                else
                {
                    typeName = dataItem.GetType().ToString();
                    ViewState["typeName"] = typeName;
                }
                Control template = TransactionTemplateFactory(typeName);
                template.ID = "trans";
                e.Item.FindControl("phTransSpecific").Controls.Add(template);
            }
        }
