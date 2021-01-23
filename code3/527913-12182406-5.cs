    public event EventHandler<ProductResultEventArgs> ProductsChosen;
    private void OnProductsChosen(List<Product> products)
    {
        var eh = ProductsChosen;
        if (eh != null) {
            eh(this, new ProductResultEventArgs(selectedProducts));
        }
    }
    private BtnOk_Click(object sender, EventArgs e)
    {
        OnProductsChosen(somehow get the product list);
    }
