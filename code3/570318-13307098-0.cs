    /// <summary>
    /// Binds the products-GridView.
    /// </summary>
    /// <param name="ProductID">the ProductID to be displayed, changes also the PageIndex if necessary</param>
    private void BindProductGrid(int ProductID = -1)
    {
        DataTable tblProducts = getAllProducts();
        GridProducts.DataSource = tblProducts;
        bool needsPaging = (tblProducts.Rows.Count / GridProducts.PageSize) > 1;
        if (ProductID == -1)
        {
            this.GridProducts.PageIndex = 0;
            this.GridProducts.SelectedIndex = -1;
        }
        else
        {
            int selectedIndex = tblProducts.AsEnumerable()
                .Select((Row, Index) => new { Row, Index })
                .Single(x => x.Row.Field<int>("ProductID") == ProductID).Index;
            int pageIndexofSelectedRow = (int)(Math.Floor(1.0 * selectedIndex / GridProducts.PageSize));
            GridProducts.PageIndex = pageIndexofSelectedRow;
            GridProducts.SelectedIndex = (int)(GridProducts.PageIndex == pageIndexofSelectedRow ? selectedIndex % GridProducts.PageSize : -1);
        }
        GridProducts.DataBind();
    }
