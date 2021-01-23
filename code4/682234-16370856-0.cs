    public void ButtonAddGoods_Click(){
        Goods newGood = new Goods();
        newGood.Id = txtProductId.Text;
        newGood.Description = txtProductDescription.Text;
        newGood.Price = txtProductPrice.Text;
    
        this.Order.AddNewGood(newGood);
    }
