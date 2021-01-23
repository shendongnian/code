       var priceList = new List<int>
                            {
                                1,
                                2,
                                3,
                                4,
                                5
                            };
    
        //Now we can use CopyTo() Method
        
        priceList.CopyTo(insuredList);
        
        ComboBox1.Datasource=priceList;
        ComboBox2.Datasource=insuredList;
   
