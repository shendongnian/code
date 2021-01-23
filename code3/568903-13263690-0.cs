    Product_D obj= db.Product_D.FirtOrDefault(t => t.PCode == pCodeTextBox.Text);
    if(obj==null){
       obj=new Product_D();
       db.Product_D.AddObject(obj);
    
    }
    
       obj.PCode = pCodeTextBox.Text;
       obj.Name = nameTextBox.Text;
       obj.Batch = batchTextBox.Text;
       obj.Expiry = expiryTextBox.Text;
       obj.Price = priceTextBox.Text;
       db.SaveChanges();
