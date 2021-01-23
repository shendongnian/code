    foreach (abcProduct p in abcProducts)
                    {
    
                        var match = (from t in dc.abcProducts
                                     where t.sku == p.productcode
                                     select t).FirstOrDefault();
    
                        if (match == null)
                        {
                           //insertion code commented out
                            dc.abcProducts.InsertOnSubmit(prod);
                        }
                        else
                        {
                            ///.... setting up all fields. 
                            match.stockPublished = false;
                            match.imgPublished = false;
                            match.prodPublished = false;
                            match.lastUpdated = DateTime.Now;
                            dc.SubmitChanges(); //Call this otherwise you will
                                                //loose the match values in the next iteration
                        }
                    }
