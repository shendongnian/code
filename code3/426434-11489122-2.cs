    protected void rpTransactions_OnItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var dataItem = e.Item.DataItem;
                string typeName;
                string viewStateKey = string.Concat("typeName", e.Item.ItemIndex);
                if (dataItem == null)
                {
                    typeName = ViewState[viewStateKey].ToString();
                }
                else
                {
                    typeName = dataItem.GetType().ToString();
                    ViewState[viewStateKey] = typeName;
                }
                Control template = TransactionTemplateFactory(typeName);
                template.ID = "trans";
                e.Item.FindControl("phTransSpecific").Controls.Add(template);
            }
        }
