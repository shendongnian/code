    [HttpGet] 
    public HttpResponseMessage List() // Not List<Item> 
    { 
        var items = _db.Items.OrderBy(x => x.ID).Select(x => new 
        { 
            ID = x.ID, 
            Title = x.Title, 
            Price = x.Price, 
            Category = new { 
                ID = x.Category.ID, 
                Name = x.Category.Name 
            } 
        }); 
     
        return Request.CreateResponse(HttpStatusCode.OK, items);
    }
