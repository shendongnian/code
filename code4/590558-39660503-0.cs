    I had similar challenge in one of my project. Below is the step that I took in resolving the problem.
    
    1. My Entity class
    
     public class Product
        {
            [Key]
            public string Id { get; set; }
            public string Title { get; set; }
            public string Album { get; set; }
            public string Artist { get; set; }
            public string Genre { get; set; }
    
        }
    
    2. Created another Class, which is defined in this form.
    	
        public class KindOfMedia
            {
                public KindOfMedia()
                {
                    Product = new List<Product>();
                }
                public List<Product> Product { get; set; }
            }
    
    3. The Web API controller, that will return json	
    
     
    
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
        	
    
    	
    4. Add this line of code to my WebApi Config file in App_Start folder
    		
         var json = config.Formatters.JsonFormatter;
                    json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
    
    please note that **Newtonsoft.Json.PreserveReferencesHandling.None**, will not preserve reference of the serialize type	
    		
    The resulting Json is 
    
    {
      "Musics": [
        {
          "Id": "bf9faeee-7c39-4c33-a0ea-f60333604061",
          "Title": "I am A Winner",
          "Album": "",
          "Artist": "Project Fame",
          "Genre": "Contemporal"
        },
        {
          "Id": "243edd32-7ba2-4ac4-8ab9-bba6399cb0a6",
          "Title": "Great Nation",
          "Album": "Oceans",
          "Artist": "Timi Dakolo",
          "Genre": "Gospel"
        }
      ]
    }
    
    		
    		
    			
