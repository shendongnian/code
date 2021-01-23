    protected void Page_Load(object sender, EventArgs e)
        {
            bindProducts();
        }
    private void bindProducts()
        {
            using (systemDbEntities context = new systemDbEntities())
            {
                var q = from c in context.Products select new { c.ProductId, c.Name };
                foreach (var item in q)
                {
                    lstProducts.InnerHtml += "<option value='" + item.Name + "'>";
                }
            }
        }
