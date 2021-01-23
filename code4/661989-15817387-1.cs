        protected void Page_Load(object sender, EventArgs e)
        {
            items = new List<CatalogItem>();
            items.Add(new CatalogItem() { Cost_Code = "ENE-Direct", Total = 33, Price = 196 });
            items.Add(new CatalogItem() { Cost_Code = "ENE-Direct", Total = 8, Price = 96 });
            items.Add(new CatalogItem() { Cost_Code = "ENE-Direct", Total = 15, Price = 1260 });
            items.Add(new CatalogItem() { Cost_Code = "ENE-Direct", Total = 10, Price = 228 });
            items.Add(new CatalogItem() { Cost_Code = "ENE-Direct", Total = 125, Price = 60 });
            items.Add(new CatalogItem() { Cost_Code = "IND038301", Total = 10, Price = 258 });
            items.Add(new CatalogItem() { Cost_Code = "IND038302", Total = 20, Price = 358 });
            items.Add(new CatalogItem() { Cost_Code = "IND038303", Total = 30, Price = 458 });
            items.Add(new CatalogItem() { Cost_Code = "IND038304", Total = 40, Price = 558 });
            this.cdcatalog.DataSource = items.GroupBy(c => c.Cost_Code).Select(c => new CatalogItem() { Cost_Code = c.Key });
            this.cdcatalog.DataBind();
        }
        protected void cdcatalog_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptItems = (Repeater)e.Item.FindControl("rptItems");
                CatalogItem catalogGroup = (CatalogItem)e.Item.DataItem;
                rptItems.DataSource = items.Where(i => i.Cost_Code == catalogGroup.Cost_Code);
                rptItems.DataBind();
                
            }
        }
