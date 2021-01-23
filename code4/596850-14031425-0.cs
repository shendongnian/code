    public List<dynamic> returnProductData(SetProduct product)
        {
            List<dynamic> productData = new List<dynamic>();
    
            var type = product.GetType();
            var properties = type.GetProperties();
    
            foreach (var propertyInfo in properties)
            {
                if( propertyInfo.GetValue(product , null) != null && propertyInfo.Name != "ProductName" &&
                    propertyInfo.Name != "Brand" && propertyInfo.Name != "ProductPrice" && propertyInfo.Name != "ProductImagePath" )
                {
                    productData.Add(new { propertyName = propertyInfo.Name , propertyValue = propertyInfo.GetValue(product , null).ToString()}) ;
                }
            }
    
            return productData;
        } 
