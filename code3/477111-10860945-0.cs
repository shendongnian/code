    public GetBLObject(string params, IDataLayerFactory dataLayerFactory)
       {
           using(DLayer dl = dataLayerFactory.Create())  // replace the "new"
           {  
                //BL logic here....    
           }
       }
