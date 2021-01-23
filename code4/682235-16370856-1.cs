    public class GoodBuilder{
        public Goods CreateGood(){
            if(string.IsEmpty(this.Id)) Throw new NullReferenceException("Goods Id is not set");
            //additional validation
            Goods newGood = new Goods();
            newGood.Id = txtProductId.Text;
            newGood.Description = txtProductDescription.Text;
            newGood.Price = txtProductPrice.Text;
            return newGood;
        }
    }
    public void ButtonAddGoods_Click(){
        GoodBuilder builder = new GoodBuilder();
        builder.Id = this.Id;
        builder.Description = this.Description;
        builder.Price = this.Price;
    
        this.Order.AddNewGood(builder.CreateGood());
    }
