                public HttpResponseMessage Products()
                {
                    var kind = new KindOfMedia();
                    kind.Products = new List<Product>();
                    kind.Products.Add(new Product
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "I am A Winner",
                        Album = "",
                        Artist = "Project Fame",
                        Genre = "Contemporal"                
                    });
                    kind.Products.Add(new Product
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "Great Nation",
                        Album = "Oceans",
                        Artist = "Timi Dakolo",
                        Genre = "Gospel"
                    });
        
                    return Request.CreateResponse(HttpStatusCode.OK, kind);
                }
        	
    
    	
